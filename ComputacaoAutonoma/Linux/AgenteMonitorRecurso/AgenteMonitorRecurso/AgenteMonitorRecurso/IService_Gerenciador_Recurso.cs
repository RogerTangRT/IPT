using System;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace AgenteMonitorRecurso
{
	[ServiceContract]
	public interface IService_Gerenciador_Recurso
	{
		[OperationContract,WebGet]
		string ReiniciaServico(string sNomeServico, string sNomeMaquina, int iTimeoutMilliseconds);
	}
}

