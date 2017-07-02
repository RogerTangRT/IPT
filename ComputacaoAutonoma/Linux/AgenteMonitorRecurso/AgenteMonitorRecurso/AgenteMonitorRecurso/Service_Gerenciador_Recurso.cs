using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.ServiceProcess;

namespace AgenteMonitorRecurso
{
	class Service_Gerenciador_Recurso : IService_Gerenciador_Recurso
	{
		const string INICIANDO_SERVIDOR = "Iniciando serviço";
		const string PARANDO_SERVIDOR = "Parando serviço";
		const string RECEBENDO_MENSAGEM = "Recebendo mensagem para reiniciar Serviço [{0}] no computador [{1}]";
		const string SERVIDOR_REINICIADO = "Servidor [{0}] reiniciado";

		public enum TipoMensagem
		{
			Recebidas,
			Interna,
			Enviadas
		};

		public Service_Gerenciador_Recurso ()
		{

		}

		private void EscreveControle(TipoMensagem tipo, string msg)
		{
			switch (tipo)
			{
			case TipoMensagem.Recebidas: 
				Console.WriteLine(" << " + msg); break;
			case TipoMensagem.Interna: 
				Console.WriteLine(" == " + msg); break;
			case TipoMensagem.Enviadas: 
				Console.WriteLine(" >> " + msg); break;
			}
		}
		internal int Execute(string exe, string args)
		{
			ProcessStartInfo oInfo = new ProcessStartInfo(exe, args);
			oInfo.UseShellExecute = false;
			oInfo.CreateNoWindow = true;

			oInfo.RedirectStandardOutput = true;
			oInfo.RedirectStandardError = true;

			StreamReader srOutput = null;
			StreamReader srError = null;

			Process proc = Process.Start(oInfo);
			proc.WaitForExit();
			srOutput = proc.StandardOutput;
			StandardOutput = srOutput.ReadToEnd();
			srError = proc.StandardError;
			StandardError = srError.ReadToEnd();
			int exitCode = proc.ExitCode;
			proc.Close();

			return exitCode;
		}

		internal string StandardOutput
		{
			get;
			private set;
		}
		internal string StandardError
		{
			get;
			private set;
		}
		private void ParaServico()
		{
			Process pr = new Process();
			ProcessStartInfo prs = new ProcessStartInfo();
			prs.FileName = "/media/Compartilhada/Servico_Monitorado/Servico_Monitorado/bin/Release/services.sh";
			prs.Arguments = "stop";
			pr.StartInfo = prs;

			ThreadStart ths = new ThreadStart(() => pr.Start());
			Thread th = new Thread(ths);
			th.Start();
		}
		private void ExecutaComandoLinux(string comando)
		{
			Process pr = new Process();
			ProcessStartInfo prs = new ProcessStartInfo();
			prs.FileName = "mono-service";
			prs.Arguments = "-l:/tmp/Servico_Monitorado.lock /media/Compartilhada/Servico_Monitorado/Servico_Monitorado/bin/Release/Servico_Monitorado.exe";
			pr.StartInfo = prs;

			ThreadStart ths = new ThreadStart(() => pr.Start());
			Thread th = new Thread(ths);
			th.Start();

		}

		public string ReiniciaServico(string sNomeServico, string sNomeMaquina, int iTimeoutMilliseconds)
		{
			EscreveControle(TipoMensagem.Recebidas,String.Format(RECEBENDO_MENSAGEM, sNomeServico, sNomeMaquina));

			EscreveControle(TipoMensagem.Interna,String.Format(PARANDO_SERVIDOR));
			ParaServico ();
			EscreveControle(TipoMensagem.Interna,String.Format(INICIANDO_SERVIDOR));
			ExecutaComandoLinux ("start");

			string msg = String.Format (SERVIDOR_REINICIADO, sNomeMaquina);
			EscreveControle(TipoMensagem.Enviadas,msg);

			return msg;
		}
	}
}

