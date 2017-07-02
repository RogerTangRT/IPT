using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceProcess;

namespace Servico_Monitorado
{
	class MainClass
	{
		#if (DEBUG != true)
		public static void Main(string[] args)
		{
			ServiceBase[] ServicesToRun;
			ServicesToRun = new ServiceBase[] { new Servico_Monitorado.Servico() };
			ServiceBase.Run(ServicesToRun);
		}
		#endif
	}
}
