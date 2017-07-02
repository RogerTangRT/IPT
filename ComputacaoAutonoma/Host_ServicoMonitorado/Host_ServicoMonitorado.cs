using Servico_Monitorado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Host_ServicoMonitorado
{
    public partial class Host_ServicoMonitorado : ServiceBase
    {
        /// <summary>
        /// Armazena o Host
        /// </summary>
        ServiceHost Host = null;
        public Host_ServicoMonitorado()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Inicia o serviço
        /// </summary>
        /// <param name="args"></param>
        protected override void OnStart(string[] args)
        {
            Host = new ServiceHost(typeof(Service_Monitorado));
            if (Host != null)
                Host.Open();
        }
        /// <summary>
        /// Para o serviço
        /// </summary>
        protected override void OnStop()
        {
            if (Host != null)
            {
                Host.Close();
                Host = null;
            }
        }
    }
}
