using GerenciadorCor;
using Orquestrador.Properties;
using Orquestrador.ServiceReference_GerenciadorCor;
using Orquestrador.ServiceReference_RespostaAgente;
using Orquestrador.ServiceReference_ServicoMonitorado;
using Orquestrador.ServiceReference_SolicitacaoAjuda;
using System;
using System.ServiceModel;

namespace Orquestrador
{
    /// <summary>
    /// Classe para gerenciar as mensagens enviadas para os agentes, e para os serviços
    /// </summary>
    class Class_Mensagens
    {
        #region Variáveis
        /// <summary>
        /// Classe para obtenção da interface WCF DUAL.
        /// </summary>
        Class_Resposta_AgenteAutonomo cls_RespostaAgenteAutonomo = new Class_Resposta_AgenteAutonomo();
        /// <summary>
        /// Ponto de envio da interface DUAL
        /// </summary>
        Service_RespostaAgenteClient clsRespostaAgenteCliente = null;
        /// <summary>
        /// Serviço de Ajuda.  ChamaAgente Autônomo
        /// </summary>
        Service_SolicitacaoAjudaClient cls_ServicoAjuda = new Service_SolicitacaoAjudaClient();
        /// <summary>
        /// Serviço de Cor
        /// </summary>
        Service_GerenciadorCorClient cls_GerenciadorCor = new Service_GerenciadorCorClient();
        /// <summary>
        /// Serviço Monitorado
        /// </summary>
        Service_MonitoradoClient cls_ServicoMonitorado;

        #endregion

        #region Propriedade
        /// <summary>
        /// Ponteiro para o formu;ário usado para callbacks.
        /// </summary>
        Form_Orquestrador Formulario { get; set; }
        #endregion

        /// <summary>
        /// Construtor. Inicializa as ligações.
        /// </summary>
        /// <param name="formulario">Ponteiro para o formulário</param>
        public Class_Mensagens(Form_Orquestrador formulario)
        {
            Formulario = formulario;
            cls_RespostaAgenteAutonomo.cls_Mensagem = this;
            InstanceContext instanceContext = new InstanceContext(cls_RespostaAgenteAutonomo);
            clsRespostaAgenteCliente = new Service_RespostaAgenteClient(instanceContext);
        }
        #region Mensagens
        /// <summary>
        /// Obtém cor do serviço do IIS
        /// </summary>
        /// <returns></returns>
        public Cor ObtemCor()
        {
            return cls_GerenciadorCor.ObtemCor();
        }
        /// <summary>
        /// Inicia esctuta da interface  DUAL. Obté o nome do primeiro servidor.
        /// </summary>
        /// <returns></returns>
        public String IniciaEscuta()
        {
            if (clsRespostaAgenteCliente != null)
            {
                return clsRespostaAgenteCliente.IniciaEscuta();
            }
            else
                return "";
        }
        /// <summary>
        /// Solicita ao Agente Autônomo que reinicie os contadores do UDDI e internos
        /// </summary>
        public void ReiniciaContadores()
        {
            cls_ServicoAjuda.ReiniciaContadores();
        }
        /// <summary>
        /// Obtém nome da máquina e endereço IP
        /// </summary>
        /// <param name="computador"></param>
        /// <param name="IPs"></param>
        /// <param name="nomeMaquina"></param>
        public void ObtemEnderecoIP(String computador, out string[] IPs, out string nomeMaquina)
        {
            EndpointAddress endpoint = new EndpointAddress(new Uri(String.Format(Resources.ResourceManager.GetString("NOME_SERVICO_MONITORADO"), computador)));
            cls_ServicoMonitorado = new Service_MonitoradoClient("ServiceHttpEndPoint", endpoint);

            IPs = cls_ServicoMonitorado.ObtemListaIP();
            nomeMaquina = cls_ServicoMonitorado.ObtemNomeMaquina();
        }
        #endregion
        /// <summary>
        /// Chama Agente autônomo quando algum erro ocorre
        /// </summary>
        /// <param name="computador">Computador</param>
        /// <param name="servico">Serviço</param>
        /// <returns></returns>
        public Exception ChamaAgenteAutonomo(String computador, String servico)
        {
            try
            {
                // Chama WCF do Agente Autônomo
                if (cls_ServicoAjuda.State == CommunicationState.Faulted)
                {
                    cls_ServicoAjuda = new Service_SolicitacaoAjudaClient();
                }
                // Chama assincronomente
                cls_ServicoAjuda.BeginReiniciaHospedeiro(computador, servico, CallBack_ReiniciaHospedeiro, null);
                return null;
            }
            catch (Exception exService)
            {
                return exService;
            }
        }
        #region Callbacks
        /// <summary>
        /// Callback para retomada do processo após a ocorrência de um erro.
        /// </summary>
        /// <param name="sMensagem">Mensagem de retorno</param>
        /// <param name="bErro">Se a mensagem é de Erro</param>
        /// <param name="sServidorAlternativo">Servidor Alternativo para tentar uma nova retransmissão</param>
        public void Callback_RetomaProcesso(String sMensagem, Boolean bErro, String sServidorAlternativo)
        {
            Formulario.Callback_RetomaProcesso(sMensagem, bErro, sServidorAlternativo);
        }
        /// <summary>
        /// Callback do reinício do Hospedeiro. Retorna a solicitação de Reinício
        /// </summary>
        /// <param name="result"></param>
        private void CallBack_ReiniciaHospedeiro(IAsyncResult result)
        {
            try
            {
                String msg = cls_ServicoAjuda.EndReiniciaHospedeiro(result);
                Formulario.CallBack_ReiniciaHospedeiro(null, msg);
            }
            catch (Exception ex)
            {
                Formulario.CallBack_ReiniciaHospedeiro(ex, "");
            }
        }
        #endregion
       

    }
}
