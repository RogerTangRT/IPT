using AgenteAutonomo.Properties;
using AgenteAutonomo.ServiceReference_AgenteMonitorRecurso;
using AgenteAutonomo.Servicos;
using ClassLibrary_Mensagens;
using System;
using System.ServiceModel;

namespace AgenteAutonomo.Agente
{
    /// <summary>
    /// Esta classe atua junto aos demais agente, enviando mensagens
    /// </summary>
    public class Class_Atuador
    {
        #region Variáveis
        /// <summary>
        /// Ponteiro para O Agente Monitor de Recurso
        /// </summary>
        public Service_Gerenciador_RecursoClient AgenteMonitorRecurso = new Service_Gerenciador_RecursoClient();
        /// <summary>
        /// Classe para retornar respostas assíncronas para o Orquestrador
        /// </summary>
        public Service_RespostaAgente RetornoRespostaAgente = new Service_RespostaAgente();
        /// <summary>
        /// Interfaceia com a Tela
        /// </summary>
        Class_InterfaceMensagens cls_InteraceMensagem;
        #endregion

        #region Propriedades
        public Class_Agente cls_Agente { get; set; }
        public Form_AgenteAutonomo Formulario { get; set; }
        #endregion

        public Class_Atuador(Class_InterfaceMensagens InteraceMensagem, Form_AgenteAutonomo formulario)
        {
            cls_InteraceMensagem = InteraceMensagem;
            Formulario = formulario;
        }
        private void AtualizaInterface()
        {
            Formulario.textBox_NomeComputador.Text = cls_Agente.Computador;
            Formulario.textBox_NomeServico.Text = cls_Agente.Servico;
        }
        public String Acessa_UDDI()
        {
            cls_InteraceMensagem.Log(Resources.ResourceManager.GetString("ACESSANDO_UDDI"));
            String maquina = cls_Agente.Servidores.cls_UDDI.ObtemProximaURL();
            cls_InteraceMensagem.Log(String.Format(Resources.ResourceManager.GetString("SERVIDOR_ENCONTRADO"), maquina));
            cls_InteraceMensagem.Envia(String.Format(Resources.ResourceManager.GetString("ENVIANDO_URL_ALTERNATIVA"), maquina));
            return maquina;
        }
        public String EnviaServidorRecuperado(String sServidor)
        {
            String msg = String.Format("Servidor Recuperado [{0}]", sServidor);
            cls_InteraceMensagem.Envia(msg);
            String sMsgRetorno = String.Format(Resources.ResourceManager.GetString("SOLICITANDO_REINICIO_SERVIDOR"), "Serviço Monitorado", sServidor);

            RetornoRespostaAgente.RetornaOrquestrador(sMsgRetorno, true, sServidor);

            return msg;
        }
        public String EnviaMensagemAgenteMonitorRecurso(bool chamaRecurso)
        {
            const int TIMEOUT_REINICIO = 1000000;
            try
            {
                if (chamaRecurso)
                {
                    AtualizaInterface();
                    cls_InteraceMensagem.Envia(String.Format(Resources.ResourceManager.GetString("SOLICITANDO_REINICIO_SERVIDOR"), cls_Agente.Servico, cls_Agente.Computador));
                    
                    EndpointAddress endpoint = new EndpointAddress(new Uri("http://" + cls_Agente.Computador + ":8734/Agente_Monitor_Recurso/Service_Gerenciador_Recurso/"));
                    AgenteMonitorRecurso = new Service_Gerenciador_RecursoClient("BasicHttpBinding_IService_Gerenciador_Recurso", endpoint);

                    AgenteMonitorRecurso.BeginReiniciaServico(cls_Agente.Servico, cls_Agente.Computador, TIMEOUT_REINICIO, cls_Agente.cls_Sensor.AsyncCallBack_ReiniciaServico, null);

                    String msg = String.Format(Resources.ResourceManager.GetString("REINICIO_SOLICITADO_COM_SUCESSO"), cls_Agente.Computador);
                    cls_InteraceMensagem.Log(msg);
                    return msg;
                }
                else
                {
                    return Resources.ResourceManager.GetString("REINICIO_JA_FOI_SOLICITADO");
                }
            }
            catch (Exception ex)
            {
                String msgErro = String.Format(Resources.ResourceManager.GetString("ERRO_SOLICITANDO_REINICIO"), Formulario.textBox_NomeComputador.Text);
                cls_InteraceMensagem.Log("Erro: " + ex.Message + "\nHResult: " + String.Format("#{0:X}", ex.HResult));
                cls_InteraceMensagem.Envia(msgErro);
                cls_Agente.GravaErro("Erro " + ex.Message);
                RetornoRespostaAgente.RetornaOrquestrador(ex.Message, true, Acessa_UDDI());
                return msgErro;
            }
        }
    }
}
