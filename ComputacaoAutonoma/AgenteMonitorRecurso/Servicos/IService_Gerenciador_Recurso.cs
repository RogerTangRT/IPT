using System;
using System.ServiceModel;

namespace AgenteMonitorRecurso.Servicos
{
    [ServiceContract]
    public interface IService_Gerenciador_Recurso
    {
        [OperationContract]
        String ReiniciaServico(String sNomeServico, String sNomeMaquina, int iTimeoutMilliseconds);
    }
}
