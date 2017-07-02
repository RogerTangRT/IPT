namespace Host_ServicoMonitorado
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.serviceProcessInstaller_ServicoMonitorado = new System.ServiceProcess.ServiceProcessInstaller();
            this.serviceInstaller_ServicoMonitorado = new System.ServiceProcess.ServiceInstaller();
            // 
            // serviceProcessInstaller_ServicoMonitorado
            // 
            this.serviceProcessInstaller_ServicoMonitorado.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.serviceProcessInstaller_ServicoMonitorado.Password = null;
            this.serviceProcessInstaller_ServicoMonitorado.Username = null;
            // 
            // serviceInstaller_ServicoMonitorado
            // 
            this.serviceInstaller_ServicoMonitorado.Description = "Serviço Monitorado. Retorna nome da Máquina e Lista de IP";
            this.serviceInstaller_ServicoMonitorado.DisplayName = "Servico Monitorado";
            this.serviceInstaller_ServicoMonitorado.ServiceName = "Servico_Monitorado";
            this.serviceInstaller_ServicoMonitorado.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceProcessInstaller_ServicoMonitorado,
            this.serviceInstaller_ServicoMonitorado});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller serviceProcessInstaller_ServicoMonitorado;
        private System.ServiceProcess.ServiceInstaller serviceInstaller_ServicoMonitorado;
    }
}