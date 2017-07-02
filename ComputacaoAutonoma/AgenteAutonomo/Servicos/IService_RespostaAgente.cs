using System;
using System.ServiceModel;

namespace AgenteAutonomo.Servicos
{
    [ServiceContract(CallbackContract = typeof(IRespostaAgente))]
    interface IService_RespostaAgente
    {
        /// <summary>
        /// Inicia interface de escuta DUAL. Retorna o primeiro servidor do UDDI
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        String IniciaEscuta();
    }
}
