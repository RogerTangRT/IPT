using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Servico_Monitorado
{
    /// <summary>
    /// Serviço monitorado. Serve para retornar o nome e os IP da máquina
    /// </summary>
    public class Service_Monitorado : IService_Monitorado
    {
        /// <summary>
        /// Retorna nome da máquina
        /// </summary>
        /// <returns></returns>
        public String ObtemNomeMaquina()
        {
            return Dns.GetHostName();
        }
        /// <summary>
        /// Retorna a lista de IPs da máquina
        /// </summary>
        /// <returns></returns>
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
