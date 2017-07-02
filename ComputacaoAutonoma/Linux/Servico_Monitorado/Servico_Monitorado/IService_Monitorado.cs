using System;
using System.ServiceModel;
using System.Collections.Generic;
using System.ServiceModel.Web;

namespace Servico_Monitorado
{
	[ServiceContract]
	public interface IService_Monitorado
	{
		[OperationContract,WebGet]
		string ObtemNomeMaquina();

		[OperationContract,WebGet]
		List<string> ObtemListaIP();
	}
}

