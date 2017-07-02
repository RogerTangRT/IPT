using System;
using System.Collections.Generic;
using System.Net;

namespace Servico_Monitorado
{
	public class Service_Monitorado: IService_Monitorado
	{
		public Service_Monitorado ()
		{
		}
		public string ObtemNomeMaquina()
		{
			return Dns.GetHostName();
		}

		public List<string> ObtemListaIP()
		{
			List<string> IPs = new List<string>();
			IPAddress[] ipaddress = Dns.GetHostAddresses(Dns.GetHostName());

			foreach (IPAddress ip in ipaddress)
			{
				IPs.Add(ip.ToString());
			}
			return IPs;
		}
	}
}

