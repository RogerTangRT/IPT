using AgenteAutonomo.Properties;
using System;
using System.ServiceModel;

namespace AgenteAutonomo.Servicos
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class Service_RespostaAgente : IService_RespostaAgente
    {
        static IRespostaAgente IResposta = null;
        /// <summary>
        /// Inicia interface de escuta DUAL. Retorna o primeiro servidor do UDDI
        /// </summary>
        /// <returns></returns>
        public String IniciaEscuta()
        {
            IResposta = OperationContext.Current.GetCallbackChannel<IRespostaAgente>();

            String sServidor = Class_Ponteiro_Form.Formulario.cls_ControleUDDI.ServidorAtual;
            Class_Ponteiro_Form.Formulario.Recebe(Resources.ResourceManager.GetString("REQUISICAO_REGISTRO_RECEBIDA"));
            Class_Ponteiro_Form.Formulario.Recebe(Resources.ResourceManager.GetString("ACESSANDO_UDDI_PARA_BUSCA_DO_SERVIDOR"));
            Class_Ponteiro_Form.Formulario.Envia(String.Format(Resources.ResourceManager.GetString("SERVIDOR_ENCONTRADO"), sServidor));
            return sServidor;
        }
        /// <summary>
        /// Retona mensagem ao orquestrador assíncronamente
        /// </summary>
        /// <param name="sMensagem">Mensagem</param>
        /// <param name="bErro">Erro</param>
        /// <param name="sServidorAlternativo">Servidor alternativo</param>
        public void RetornaOrquestrador(String sMensagem, Boolean bErro, String sServidorAlternativo)
        {
            if (IResposta != null)
                IResposta.Responde(sMensagem, bErro, sServidorAlternativo);
        }
    }
}
