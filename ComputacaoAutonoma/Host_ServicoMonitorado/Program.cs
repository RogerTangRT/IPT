using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Host_ServicoMonitorado
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada da aplicação
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Host_ServicoMonitorado()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
