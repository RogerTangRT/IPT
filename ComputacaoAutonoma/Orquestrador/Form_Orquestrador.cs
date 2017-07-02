using ClassLibrary_Mensagens;
using GerenciadorCor;
using Orquestrador.Properties;
using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace Orquestrador
{
    public partial class Form_Orquestrador : Form
    {

        #region Variáveis
        /// <summary>
        /// Interface com a tela.
        /// </summary>
        Class_InterfaceMensagens cls_InterfaceMensagem = null;
        /// <summary>
        /// Envia e recebe as mensagens
        /// </summary>
        Class_Mensagens cls_Mensagens = null;
        #endregion

        #region Propriedades
        String ServidorAtual { get; set; }
        #endregion

        /// <summary>
        /// Construtor. Inicializa componentes do formulário. Inicializa classe de mensagens com os controles
        /// </summary>
        public Form_Orquestrador()
        {
            InitializeComponent();

            cls_InterfaceMensagem = new Class_InterfaceMensagens(
                richTextBox_Enviadas,
                richTextBox_Recebidas,
                richTextBox_Internas,
                this);
            cls_Mensagens = new Class_Mensagens(this);
        }
       
        /// <summary>
        /// Carga do formulário.
        /// 1) Inicia a Interface de Resposta
        /// 2) Solicita um servidor ao Agente Autônomo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Orquestrador_Load(object sender, EventArgs e)
        {
            IniciaEscuta();
        }
        /// <summary>
        /// Chama o Agente autônomo em caso de erro
        /// </summary>
        private void ChamaAgenteAutonomo()
        {
            String servico = textBox_NomeServico.Text;
            String computador = textBox_NomeComputador.Text;

            // Chama assincronomente
            cls_InterfaceMensagem.Log(String.Format(Resources.ResourceManager.GetString("SOLICITACAO_REINICIO"), servico, computador));
            Exception exService = cls_Mensagens.ChamaAgenteAutonomo(computador, servico);
            if (exService != null)
                cls_InterfaceMensagem.Recebe(String.Format(Resources.ResourceManager.GetString("ERRO_HRESULT"), String.Format("#{0:X}", exService.HResult), exService.Message));
        }
        /// <summary>
        /// Limpa os controles
        /// </summary>
        private void LimpaControles()
        {
            cls_InterfaceMensagem.Apaga(richTextBoxProcessoIP);
            cls_InterfaceMensagem.AlteraCor(Color.White, textBoxProcessoCor1);
            cls_InterfaceMensagem.AlteraCor(Color.White, textBoxProcessoCor2);
        }

        #region Processo
        /// <summary>
        /// Inicia o processo de escuta. Obtém o nome da primeira máquina do UDDI
        /// </summary>
        private void IniciaEscuta()
        {
            cls_InterfaceMensagem.Envia(Resources.ResourceManager.GetString("SOLICITACAO_ESCUTA"));
            try
            {
                ServidorAtual = cls_Mensagens.IniciaEscuta();
                if (ServidorAtual != "")
                {
                    cls_InterfaceMensagem.Recebe(string.Format(Resources.ResourceManager.GetString("SERVIDOR_INICIAL"), ServidorAtual));
                    textBox_NomeComputador.Text = ServidorAtual;
                }
                else
                    cls_InterfaceMensagem.Log(Resources.ResourceManager.GetString("ERRO_OBTENDO_SERVIDOR"));
            }
            catch (Exception ex)
            {
                cls_InterfaceMensagem.Log(ex.Message);
            }
        }
        /// <summary>
        /// Alera a cor do controle
        /// </summary>
        /// <param name="processo"></param>
        private void AlteraCor(int processo)
        {
            try
            {
                cls_InterfaceMensagem.Envia(String.Format(Resources.ResourceManager.GetString("PROCESSO"), processo, Dns.GetHostName() + "/IIS", "Obtendo Cor"));
                Cor c = cls_Mensagens.ObtemCor();
                cls_InterfaceMensagem.Recebe(String.Format(Resources.ResourceManager.GetString("PROCESSO_RESULTADO"), processo, Dns.GetHostName() + "/IIS", "Obtem Cor", String.Format(Resources.ResourceManager.GetString("RGB"), c.R, c.G, c.B)));
                Color color = Color.FromArgb(c.R, c.G, c.G);
                switch (processo)
                {
                    case 1:
                        cls_InterfaceMensagem.AlteraCor(color, textBoxProcessoCor1);
                        break;
                    case 3:
                        cls_InterfaceMensagem.AlteraCor(color, textBoxProcessoCor2);
                        break;
                }
            }
            catch (Exception ex)
            {
                cls_InterfaceMensagem.Log(ex.Message);
            }
        }
        /// <summary>
        /// Obtém nome e endereço IP
        /// </summary>
        private void ObtemEnderecoIP()
        {
         
            cls_InterfaceMensagem.Envia(String.Format(Resources.ResourceManager.GetString("PROCESSO"), 2, textBox_NomeComputador.Text, "Solicitando Nome e IP"));
            
            string[] IPs;
            string nomeMaquina;
            cls_Mensagens.ObtemEnderecoIP(textBox_NomeComputador.Text, out IPs, out nomeMaquina);
            cls_InterfaceMensagem.Escreve("Nome:" + nomeMaquina, richTextBoxProcessoIP);

            foreach (string ip in IPs)
            {
                cls_InterfaceMensagem.Escreve("IP:" + ip, richTextBoxProcessoIP);
            }
            cls_InterfaceMensagem.Recebe(String.Format(Resources.ResourceManager.GetString("PROCESSO_RESULTADO"), 2, textBox_NomeComputador.Text, "Obtenção Nome e IP", nomeMaquina));
        }
        #endregion

        #region Callbacks
        /// <summary>
        /// Retoma Processo. Depois de um erro ser tratato tenta retomar o andamento do processo
        /// </summary>
        /// <param name="sMensagem">Mensagem</param>
        /// <param name="bErro">Se é erro</param>
        /// <param name="sServidorAlternativo">Servidor alternativo para retentativa</param>
        public void Callback_RetomaProcesso(String sMensagem, Boolean bErro, String sServidorAlternativo)
        {
            try
            {
                cls_InterfaceMensagem.Recebe(sMensagem);
                if (bErro == true)
                {
                    cls_InterfaceMensagem.Recebe(String.Format(Resources.ResourceManager.GetString("RECEBENDO_URL_ALTERNATIVA"), sServidorAlternativo));

                    cls_InterfaceMensagem.Log(String.Format(Resources.ResourceManager.GetString("ACESSANDO_SERVIDOR_ALTERNATIVO"), sServidorAlternativo));
                    cls_InterfaceMensagem.EscreveTextBox(sServidorAlternativo, textBox_NomeComputador);
                }
                ObtemEnderecoIP();
                AlteraCor(3);
            }
            catch (Exception exService)
            {
                cls_InterfaceMensagem.Log(String.Format(Resources.ResourceManager.GetString("ERRO_HRESULT"), String.Format("#{0:X}", exService.HResult), exService.Message));
                const UInt32 SERVICO_NAO_RESPONDE = 0x80131501;
                const UInt32 TIME_OUT = 0x80131505;
                if ((UInt32)exService.HResult == SERVICO_NAO_RESPONDE || (UInt32)exService.HResult == TIME_OUT)
                {
                    ChamaAgenteAutonomo();
                }
            }
        }
        /// <summary>
        /// Retorno da Função de reinício do hospedeiro
        /// </summary>
        /// <param name="execao">Exceção</param>
        /// <param name="sMensagem"></param>
        public void CallBack_ReiniciaHospedeiro(Exception execao, String sMensagem)
        {
            if (execao == null)
            {
                cls_InterfaceMensagem.Recebe(sMensagem);
                if (sMensagem == Resources.ResourceManager.GetString("REINICIO_JA_SOLICITADO_TRANSACAO_DEVE_SER_DESFEITA"))
                {
                    cls_InterfaceMensagem.Log(Resources.ResourceManager.GetString("DESFAZENDO_TRANSACAO"));
                    LimpaControles();
                }
            }
            else
            {
                cls_InterfaceMensagem.Recebe(execao.Message);
            }
        }

        #endregion

        #region Botões
        /// <summary>
        /// Trata botão de Início do Processo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_IniciaProcesso_Click(object sender, EventArgs e)
        {
            try
            {
                LimpaControles();
                AlteraCor(1);
                ObtemEnderecoIP();
                AlteraCor(3);
            }
            catch (Exception ex)
            {
                cls_InterfaceMensagem.Log(ex.Message);
                const UInt32 SERVICO_NAO_RESPONDE = 0x80131501;
                const UInt32 TIMEOUT_SERVICO = 0x80131505;
                if ((UInt32)ex.HResult == SERVICO_NAO_RESPONDE ||
                    (UInt32)ex.HResult == TIMEOUT_SERVICO)
                {
                    ChamaAgenteAutonomo();
                }
            }
        }
        /// <summary>
        /// Limpa os controles eenvia mensagem para Agente Autônomo para reinício
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_LimpaMensagens_Click(object sender, EventArgs e)
        {
            // Apaga RichText Enviadas Recebibas e Internas
            cls_InterfaceMensagem.Apaga(richTextBox_Recebidas);
            cls_InterfaceMensagem.Apaga(richTextBox_Enviadas);
            cls_InterfaceMensagem.Apaga(richTextBox_Internas);
            // Apaga controles do Processo
            LimpaControles();
            // Reinicia contador de mensagens
            cls_InterfaceMensagem.ReiniciaContador();
        }
       

        private void button_Reinicializa_Agentes_Click(object sender, EventArgs e)
        {
          
            // Seta o servidor para o servidor atual
            textBox_NomeComputador.Text = ServidorAtual;
            // Reinicia contador do Agente Autônomo
            cls_Mensagens.ReiniciaContadores();
            IniciaEscuta();
        }
        #endregion
    }
}
