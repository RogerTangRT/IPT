using AgenteAutonomo.Agente;
using AgenteAutonomo.Properties;
using AgenteAutonomo.Servicos;
using ClassLibrary_Mensagens;
using ClassLibrary_UDDI;
using System;
using System.Security.Principal;
using System.ServiceModel;
using System.Windows.Forms;

namespace AgenteAutonomo
{

    /// <summary>
    /// Formulário do Agente Autônomo.
    /// Inicializa o ponteiro do formulário
    /// Inicia o nome do computador com 
    /// </summary>
    public partial class Form_AgenteAutonomo : Form
    {
        #region Variáveis
        /// <summary>
        /// Serviço de Escuta de Ajuda. Chamada pelo Orquestrados
        /// </summary>
        ServiceHost Service_SolicitacaoAjuda = null;
        /// <summary>
        /// Serviço de Resposta assíncrona
        /// </summary>
        ServiceHost Service_RespostaAgente = null;
        /// <summary>
        /// Classe de interface com as mensagens. Escreve nos controles
        /// </summary>
        public Class_InterfaceMensagens cls_InteraceMensagem = null;
        /// <summary>
        /// Classe de UDDI
        /// </summary>
        Class_UDDI cls_UDDI = new Class_UDDI();
        /// <summary>
        /// Classe de controle do UDDI
        /// </summary>
        public Class_ControleUDDI cls_ControleUDDI = null;

        #region Agentes
        /// <summary>
        /// Agente Principal
        /// </summary>
        Class_Agente cls_Agente = null;
        /// <summary>
        /// Sensor do agente
        /// </summary>
        Class_Atuador cls_AgenteAtuador;
        /// <summary>
        /// Atuador do agente
        /// </summary>
        Class_Sensor cls_AgenteSensor;
        #endregion
        #endregion

        /// <summary>
        /// Construtor.  Efetua as ligações
        /// </summary>
        public Form_AgenteAutonomo()
        {
            InitializeComponent();

            Class_Ponteiro_Form.Formulario = this;

            cls_InteraceMensagem = new Class_InterfaceMensagens(
               richTextBox_Enviadas,
               richTextBox_Recebidas,
               richTextBox_Internas,
               this);
        }
        /// <summary>
        /// Verifica se está em modo Administrador
        /// </summary>
        /// <returns></returns>
        private Boolean E_Admin()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
        #region Interface
        /// <summary>
        /// Limpa controles. Reinicia o contador de mensagens e as variáveis internas do agente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_LimpaMensagens_Click(object sender, EventArgs e)
        {
            cls_InteraceMensagem.Apaga(richTextBox_Recebidas);
            cls_InteraceMensagem.Apaga(richTextBox_Enviadas);
            cls_InteraceMensagem.Apaga(richTextBox_Internas);
            cls_InteraceMensagem.ReiniciaContador();
        }

        /// <summary>
        /// Inicializa formulário
        /// Carrega UDDI do Arquivo XML
        /// Inicializa Interface de Solicitação de Ajuda
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_AgenteAutonomo_Load(object sender, EventArgs e)
        {
            if (!E_Admin())
                cls_InteraceMensagem.Log(Resources.ResourceManager.GetString("EXECUTE_COMO_ADMIN"));
            else
            {
                cls_AgenteAtuador = new Class_Atuador(cls_InteraceMensagem, this);

                cls_AgenteSensor = new Class_Sensor();
                cls_Agente = new Class_Agente(cls_UDDI, cls_AgenteAtuador, cls_AgenteSensor);
                cls_ControleUDDI = new Class_ControleUDDI(cls_UDDI, listBoxUDDI);
                textBox_NomeComputador.Text = listBoxUDDI.Items[0].ToString();

                InicializaInterface_ServiceSolicitacaoAjuda();
                InicializaInterface_ServiceResposta();
            }
        }
        #endregion

        #region Inicializa interfaces de escuta
        /// <summary>
        /// Inicializa interface de escuta WCF para solicitação de Ajuda.
        /// Esta interface será chamada pelo orquestrador
        /// </summary>
        private void InicializaInterface_ServiceSolicitacaoAjuda()
        {
            Service_SolicitacaoAjuda = new ServiceHost(typeof(Service_SolicitacaoAjuda));
            Service_SolicitacaoAjuda.Open();
            cls_InteraceMensagem.Log(Resources.ResourceManager.GetString("SERVICO_SOLICITACAO_AJUDA_INICIADO"));
        }
        /// <summary>
        /// Inicializa interface de Respossta DUAL. Usado para envio de mensagens assíncronas
        /// </summary>
        private void InicializaInterface_ServiceResposta()
        {
            Service_RespostaAgente = new ServiceHost(typeof(Service_RespostaAgente));
            Service_RespostaAgente.Open();
            cls_InteraceMensagem.Log(Resources.ResourceManager.GetString("SERVICO_RESPOSTA_AGENTE_INICIADO"));
        }
        #endregion

        #region Mensagens do WCF
        /// <summary>
        /// Escreve mensagem vindas do contexto da chamada WCF
        /// </summary>
        /// <param name="msg"></param>
        public void Recebe(string msg)
        {
            cls_InteraceMensagem.Recebe(msg);
        }
        /// <summary>
        /// Envia mensagem WCF
        /// </summary>
        /// <param name="msg"></param>
        public void Envia(string msg)
        {
            cls_InteraceMensagem.Envia(msg);
        }
        /// <summary>
        /// Reinicia hospedeiro do serviço, chamando Agente Monnitor de Recurso
        /// </summary>
        /// <param name="sNomeComputador">Nome do Computador</param>
        /// <param name="sNomeServico">Nome do Serviço</param>
        /// <returns></returns>
        public string Reinicia(String sNomeComputador, String sNomeServico)
        {
            return cls_Agente.Reinicia(sNomeComputador, sNomeServico);
        }
        /// <summary>
        /// Callback recebido pelo Orquestrador para reinício
        /// </summary>
        public void ReiniciaContadores()
        {
            button_Reinicializa_Agentes_Click(null, null);
        }
        #endregion
        /// <summary>
        /// Finaliza escutas dos WCFs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_AgenteAutonomo_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (Service_SolicitacaoAjuda != null)
                    Service_SolicitacaoAjuda.Close();
                if (Service_RespostaAgente != null)
                    Service_RespostaAgente.Close();
            }
            catch (Exception ex)
            {
                cls_InteraceMensagem.Log(ex.Message);
            }
        }
        public void ServicoReativado(String sNomeComputador)
        {
            cls_Agente.Servidores.ReativaServico(sNomeComputador);
        }
        private void button_ReativaServico_Click(object sender, EventArgs e)
        {
            ServicoReativado(textBox_NomeComputador.Text);
        }

        private void button_Reinicializa_Agentes_Click(object sender, EventArgs e)
        {
            cls_Agente.Servidores.ReiniciaContadorServidores();
        }
    }
}
