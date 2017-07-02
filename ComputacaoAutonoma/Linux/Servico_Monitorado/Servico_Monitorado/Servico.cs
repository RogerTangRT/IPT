using System;
using System.ServiceProcess;
using System.ServiceModel;

namespace Servico_Monitorado
{
	public class Servico : ServiceBase
	{
		ServiceHost host = new ServiceHost(typeof(Servico_Monitorado.Service_Monitorado));

		protected override void OnStart(string[] args)
		{
			host.Open ();
			Console.WriteLine ("Serviço Monitorado iniciado!");
		}

		protected override void OnStop()
		{
			Console.WriteLine ("Serviço Monitorado finalizado!");
			host.Close ();
		}

		#if DEBUG
		// This method is for debugging of OnStart() method only.
		// Switch to Debug config, set a breakpoint here and a breakpoint in OnStart()
		// How to: Debug the OnStart Method http://msdn.microsoft.com/en-us/library/cktt23yw.aspx
		// How to: Debug Windows Service Applications http://msdn.microsoft.com/en-us/library/7a50syb3%28v=vs.110%29.aspx
		public static void Main(string[] args)
		{
			Console.WriteLine("Iniciando Serviço modo DEBUG");
			(new Servico_Monitorado.Servico()).OnStart(new string[1]);
		}
		#endif
	}
}

