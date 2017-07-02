using AgenteMonitorRecurso.Properties;
using AgenteMonitorRecurso.ServiceReference_SolicitacaoAjuda;
using AgenteMonitorRecurso.Servicos;
using ClassLibrary_Mensagens;
using System;
using System.Net;
using System.Security.Principal;
using System.ServiceModel;
using System.ServiceProcess;
using System.Windows.Forms;

namespace AgenteMonitorRecurso
{
    public partial class FormMonitorRecurso : Form
    {
        const int TIMEOUT_SERVICO_PARADO = 10000;
        #region Variáveis
        /// <summary>
        /// Serviço de Ajuda.  ChamaAgente Autônomo
        /// </summary>
        Service_SolicitacaoAjudaClient cls_ServicoAjuda = new Service_SolicitacaoAjudaClient();
        public Class_InterfaceMensagens cls_InterfaceMensagem = null;
        #endregion

        private String NomeMaquina { get; set; }
        private String NomeServico { get; set; }

        ServiceHost GerenciadorRecurso;
        public FormMonitorRecurso()
        {
            InitializeComponent();
            Class_Ponteiro_Form.Formulario = this;
            cls_InterfaceMensagem = new Class_InterfaceMensagens(
                richTextBox_Enviadas,
                richTextBox_Recebidas,
                richTextBox_Internas,
                this);

        }
        /// <summary>
        /// Verifica se está sendo executado no modo administrador
        /// </summary>
        /// <returns></returns>
        private Boolean E_Admin()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
       
        private void FormMonitorRecurso_Load(object sender, EventArgs e)
        {
            try
            {
                if (!E_Admin())
                    cls_InterfaceMensagem.Log(Resources.ResourceManager.GetString("EXECUTE_COMO_ADMIN"));
                else
                {
                    try
                    {
                        // Inicia WCF auto-contido.
                        GerenciadorRecurso = new ServiceHost(typeof(Service_Gerenciador_Recurso));
                        GerenciadorRecurso.Open();
                        cls_InterfaceMensagem.Log(Resources.ResourceManager.GetString("SERVICO_GERENCIADOR_RECURSO_INICIADO"));
                    }
                    catch (Exception ex)
                    {
                        cls_InterfaceMensagem.Log(ex.Message);
                    }

                }
            }
            catch (Exception ex)
            {
                cls_InterfaceMensagem.Log(ex.Message);
            }
        }
        /// <summary>
        /// Limpa as mensaens da tela
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_LimpaMensagens_Click(object sender, EventArgs e)
        {
            cls_InterfaceMensagem.Apaga(richTextBox_Recebidas);
            cls_InterfaceMensagem.Apaga(richTextBox_Internas);
            cls_InterfaceMensagem.Apaga(richTextBox_Enviadas);
            cls_InterfaceMensagem.ReiniciaContador();
        }

        private void button_Reinicia_Servico_Click(object sender, EventArgs e)
        {
            Service_Gerenciador_Recurso GerenciadorRecurso = new Service_Gerenciador_Recurso();
            if (textBox_NomeServico.Text == "")
            {
                cls_InterfaceMensagem.Log(Resources.ResourceManager.GetString("ENTRE_COM_NOME_DO_SERVICO"));
            }
            else
            {
                if (textBox_NomeComputador.Text == "")
                {
                    cls_InterfaceMensagem.Log(Resources.ResourceManager.GetString("ENTRE_COM_NOME_COMPUTADOR"));
                }
                else
                {
                    try
                    {
                        GerenciadorRecurso.ReiniciaServico(textBox_NomeServico.Text, textBox_NomeComputador.Text, TIMEOUT_SERVICO_PARADO);
                    }
                    catch (Exception ex)
                    {
                        cls_InterfaceMensagem.Log(ex.Message);
                    }
                }
            }
        }

        private void FormMonitorRecurso_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (GerenciadorRecurso != null)
                    GerenciadorRecurso.Close();
            }
            catch (Exception ex)
            {
                cls_InterfaceMensagem.Log(ex.Message);
            }
        }
        public void LigaTimerServidorAtivo(String sNomeMaquina, String sNomeServico)
        {
            timer_VerificaServidorAtivo.Enabled = true;
            NomeMaquina = sNomeMaquina;
            NomeServico = sNomeServico;
            checkBox_Checando_Recurso_Monitorado.Checked = true;
        }
        private void button_ReativaServico_Click(object sender, EventArgs e)
        {
            cls_InterfaceMensagem.Log(Resources.ResourceManager.GetString("REATIVANDO_SERVICO"));
            cls_ServicoAjuda.ServicoReativado(Dns.GetHostName());
        }
        /// <summary>
        /// Verifica se o servidor está ativo tentando reativar o servidor.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_VerificaServidorAtivo_Tick(object sender, EventArgs e)
        {
            Class_Timer cls_Timer = new Class_Timer(TIMEOUT_SERVICO_PARADO);
            ServiceController service = new ServiceController(NomeServico, NomeMaquina);
            try
            {
                cls_Timer.RegisterTime();
                service.Start();
                service.WaitForStatus(ServiceControllerStatus.Running, cls_Timer.Timeout);

                timer_VerificaServidorAtivo.Enabled = false;
                checkBox_Checando_Recurso_Monitorado.Checked = false;
                button_ReativaServico_Click(null,null);
            }
            catch (Exception)
            {
            }
        }
    }
}
