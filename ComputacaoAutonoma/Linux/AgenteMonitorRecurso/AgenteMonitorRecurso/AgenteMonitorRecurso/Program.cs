using System;
using System.ServiceModel;
using System.Diagnostics;

namespace AgenteMonitorRecurso
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			try
			{
			Console.WriteLine ("Agente Monitor de Recurso");
			Console.WriteLine ("=========================");
			ServiceHost GerenciadorRecurso;
			GerenciadorRecurso = new ServiceHost(typeof(Service_Gerenciador_Recurso));
			GerenciadorRecurso.Open();

			Console.WriteLine ("Serviço iniciado!");
			Console.WriteLine ("Pressione <ENTER> sair");
			Console.ReadLine ();
			GerenciadorRecurso.Close ();
			}
			catch(Exception ex) {
				Console.WriteLine (ex.Message);
			}
		}
	}
}
