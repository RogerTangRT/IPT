namespace AgenteMonitorRecurso
{
    partial class FormMonitorRecurso
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMonitorRecurso));
            this.groupBox_Mensagens = new System.Windows.Forms.GroupBox();
            this.richTextBox_Enviadas = new System.Windows.Forms.RichTextBox();
            this.label_Enviadas = new System.Windows.Forms.Label();
            this.richTextBox_Internas = new System.Windows.Forms.RichTextBox();
            this.label_Internas = new System.Windows.Forms.Label();
            this.label_Recebidas = new System.Windows.Forms.Label();
            this.richTextBox_Recebidas = new System.Windows.Forms.RichTextBox();
            this.groupBox_Controles = new System.Windows.Forms.GroupBox();
            this.checkBox_Checando_Recurso_Monitorado = new System.Windows.Forms.CheckBox();
            this.button_ReativaServico = new System.Windows.Forms.Button();
            this.textBox_NomeComputador = new System.Windows.Forms.TextBox();
            this.label_NomeComputador = new System.Windows.Forms.Label();
            this.textBox_NomeServico = new System.Windows.Forms.TextBox();
            this.label_NomeServico = new System.Windows.Forms.Label();
            this.button_Reinicia_Servico = new System.Windows.Forms.Button();
            this.button_LimpaMensagens = new System.Windows.Forms.Button();
            this.timer_VerificaServidorAtivo = new System.Windows.Forms.Timer(this.components);
            this.groupBox_Mensagens.SuspendLayout();
            this.groupBox_Controles.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_Mensagens
            // 
            this.groupBox_Mensagens.Controls.Add(this.richTextBox_Enviadas);
            this.groupBox_Mensagens.Controls.Add(this.label_Enviadas);
            this.groupBox_Mensagens.Controls.Add(this.richTextBox_Internas);
            this.groupBox_Mensagens.Controls.Add(this.label_Internas);
            this.groupBox_Mensagens.Controls.Add(this.label_Recebidas);
            this.groupBox_Mensagens.Controls.Add(this.richTextBox_Recebidas);
            this.groupBox_Mensagens.Location = new System.Drawing.Point(12, 12);
            this.groupBox_Mensagens.Name = "groupBox_Mensagens";
            this.groupBox_Mensagens.Size = new System.Drawing.Size(620, 541);
            this.groupBox_Mensagens.TabIndex = 1;
            this.groupBox_Mensagens.TabStop = false;
            this.groupBox_Mensagens.Text = "Mensagens";
            // 
            // richTextBox_Enviadas
            // 
            this.richTextBox_Enviadas.ForeColor = System.Drawing.Color.ForestGreen;
            this.richTextBox_Enviadas.Location = new System.Drawing.Point(6, 385);
            this.richTextBox_Enviadas.Name = "richTextBox_Enviadas";
            this.richTextBox_Enviadas.ReadOnly = true;
            this.richTextBox_Enviadas.Size = new System.Drawing.Size(600, 150);
            this.richTextBox_Enviadas.TabIndex = 5;
            this.richTextBox_Enviadas.Text = "";
            // 
            // label_Enviadas
            // 
            this.label_Enviadas.AutoSize = true;
            this.label_Enviadas.Location = new System.Drawing.Point(3, 369);
            this.label_Enviadas.Name = "label_Enviadas";
            this.label_Enviadas.Size = new System.Drawing.Size(51, 13);
            this.label_Enviadas.TabIndex = 4;
            this.label_Enviadas.Text = "Enviadas";
            // 
            // richTextBox_Internas
            // 
            this.richTextBox_Internas.ForeColor = System.Drawing.Color.Red;
            this.richTextBox_Internas.Location = new System.Drawing.Point(6, 216);
            this.richTextBox_Internas.Name = "richTextBox_Internas";
            this.richTextBox_Internas.ReadOnly = true;
            this.richTextBox_Internas.Size = new System.Drawing.Size(600, 150);
            this.richTextBox_Internas.TabIndex = 3;
            this.richTextBox_Internas.Text = "";
            // 
            // label_Internas
            // 
            this.label_Internas.AutoSize = true;
            this.label_Internas.Location = new System.Drawing.Point(3, 200);
            this.label_Internas.Name = "label_Internas";
            this.label_Internas.Size = new System.Drawing.Size(74, 13);
            this.label_Internas.TabIndex = 2;
            this.label_Internas.Text = "Internas / Log";
            // 
            // label_Recebidas
            // 
            this.label_Recebidas.AutoSize = true;
            this.label_Recebidas.Location = new System.Drawing.Point(3, 31);
            this.label_Recebidas.Name = "label_Recebidas";
            this.label_Recebidas.Size = new System.Drawing.Size(58, 13);
            this.label_Recebidas.TabIndex = 1;
            this.label_Recebidas.Text = "Recebidas";
            // 
            // richTextBox_Recebidas
            // 
            this.richTextBox_Recebidas.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.richTextBox_Recebidas.Location = new System.Drawing.Point(6, 47);
            this.richTextBox_Recebidas.Name = "richTextBox_Recebidas";
            this.richTextBox_Recebidas.ReadOnly = true;
            this.richTextBox_Recebidas.Size = new System.Drawing.Size(600, 150);
            this.richTextBox_Recebidas.TabIndex = 0;
            this.richTextBox_Recebidas.Text = "";
            // 
            // groupBox_Controles
            // 
            this.groupBox_Controles.Controls.Add(this.checkBox_Checando_Recurso_Monitorado);
            this.groupBox_Controles.Controls.Add(this.button_ReativaServico);
            this.groupBox_Controles.Controls.Add(this.textBox_NomeComputador);
            this.groupBox_Controles.Controls.Add(this.label_NomeComputador);
            this.groupBox_Controles.Controls.Add(this.textBox_NomeServico);
            this.groupBox_Controles.Controls.Add(this.label_NomeServico);
            this.groupBox_Controles.Controls.Add(this.button_Reinicia_Servico);
            this.groupBox_Controles.Controls.Add(this.button_LimpaMensagens);
            this.groupBox_Controles.Location = new System.Drawing.Point(638, 13);
            this.groupBox_Controles.Name = "groupBox_Controles";
            this.groupBox_Controles.Size = new System.Drawing.Size(244, 540);
            this.groupBox_Controles.TabIndex = 2;
            this.groupBox_Controles.TabStop = false;
            this.groupBox_Controles.Text = "Controles";
            // 
            // checkBox_Checando_Recurso_Monitorado
            // 
            this.checkBox_Checando_Recurso_Monitorado.AutoSize = true;
            this.checkBox_Checando_Recurso_Monitorado.Location = new System.Drawing.Point(9, 233);
            this.checkBox_Checando_Recurso_Monitorado.Name = "checkBox_Checando_Recurso_Monitorado";
            this.checkBox_Checando_Recurso_Monitorado.Size = new System.Drawing.Size(174, 17);
            this.checkBox_Checando_Recurso_Monitorado.TabIndex = 10;
            this.checkBox_Checando_Recurso_Monitorado.Text = "Checando Recurso Monitorado";
            this.checkBox_Checando_Recurso_Monitorado.UseVisualStyleBackColor = true;
            // 
            // button_ReativaServico
            // 
            this.button_ReativaServico.Location = new System.Drawing.Point(8, 95);
            this.button_ReativaServico.Name = "button_ReativaServico";
            this.button_ReativaServico.Size = new System.Drawing.Size(230, 23);
            this.button_ReativaServico.TabIndex = 9;
            this.button_ReativaServico.Text = "Reativa Serviço";
            this.button_ReativaServico.UseVisualStyleBackColor = true;
            this.button_ReativaServico.Click += new System.EventHandler(this.button_ReativaServico_Click);
            // 
            // textBox_NomeComputador
            // 
            this.textBox_NomeComputador.Location = new System.Drawing.Point(9, 196);
            this.textBox_NomeComputador.Name = "textBox_NomeComputador";
            this.textBox_NomeComputador.Size = new System.Drawing.Size(230, 20);
            this.textBox_NomeComputador.TabIndex = 5;
            // 
            // label_NomeComputador
            // 
            this.label_NomeComputador.AutoSize = true;
            this.label_NomeComputador.Location = new System.Drawing.Point(6, 180);
            this.label_NomeComputador.Name = "label_NomeComputador";
            this.label_NomeComputador.Size = new System.Drawing.Size(95, 13);
            this.label_NomeComputador.TabIndex = 4;
            this.label_NomeComputador.Text = "Nome Computador";
            // 
            // textBox_NomeServico
            // 
            this.textBox_NomeServico.Location = new System.Drawing.Point(9, 153);
            this.textBox_NomeServico.Name = "textBox_NomeServico";
            this.textBox_NomeServico.Size = new System.Drawing.Size(230, 20);
            this.textBox_NomeServico.TabIndex = 3;
            // 
            // label_NomeServico
            // 
            this.label_NomeServico.AutoSize = true;
            this.label_NomeServico.Location = new System.Drawing.Point(6, 137);
            this.label_NomeServico.Name = "label_NomeServico";
            this.label_NomeServico.Size = new System.Drawing.Size(89, 13);
            this.label_NomeServico.TabIndex = 2;
            this.label_NomeServico.Text = "Nome do Serviço";
            // 
            // button_Reinicia_Servico
            // 
            this.button_Reinicia_Servico.Location = new System.Drawing.Point(9, 66);
            this.button_Reinicia_Servico.Name = "button_Reinicia_Servico";
            this.button_Reinicia_Servico.Size = new System.Drawing.Size(229, 23);
            this.button_Reinicia_Servico.TabIndex = 1;
            this.button_Reinicia_Servico.Text = "Reiniciar Serviço";
            this.button_Reinicia_Servico.UseVisualStyleBackColor = true;
            this.button_Reinicia_Servico.Click += new System.EventHandler(this.button_Reinicia_Servico_Click);
            // 
            // button_LimpaMensagens
            // 
            this.button_LimpaMensagens.Location = new System.Drawing.Point(9, 37);
            this.button_LimpaMensagens.Name = "button_LimpaMensagens";
            this.button_LimpaMensagens.Size = new System.Drawing.Size(229, 23);
            this.button_LimpaMensagens.TabIndex = 0;
            this.button_LimpaMensagens.Text = "Limpar Mensagens";
            this.button_LimpaMensagens.UseVisualStyleBackColor = true;
            this.button_LimpaMensagens.Click += new System.EventHandler(this.button_LimpaMensagens_Click);
            // 
            // timer_VerificaServidorAtivo
            // 
            this.timer_VerificaServidorAtivo.Interval = 1000;
            this.timer_VerificaServidorAtivo.Tick += new System.EventHandler(this.timer_VerificaServidorAtivo_Tick);
            // 
            // FormMonitorRecurso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 560);
            this.Controls.Add(this.groupBox_Controles);
            this.Controls.Add(this.groupBox_Mensagens);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMonitorRecurso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agente Monitor de Recurso";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMonitorRecurso_FormClosed);
            this.Load += new System.EventHandler(this.FormMonitorRecurso_Load);
            this.groupBox_Mensagens.ResumeLayout(false);
            this.groupBox_Mensagens.PerformLayout();
            this.groupBox_Controles.ResumeLayout(false);
            this.groupBox_Controles.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_Mensagens;
        private System.Windows.Forms.RichTextBox richTextBox_Enviadas;
        private System.Windows.Forms.Label label_Enviadas;
        private System.Windows.Forms.RichTextBox richTextBox_Internas;
        private System.Windows.Forms.Label label_Internas;
        private System.Windows.Forms.Label label_Recebidas;
        private System.Windows.Forms.RichTextBox richTextBox_Recebidas;
        private System.Windows.Forms.GroupBox groupBox_Controles;
        public System.Windows.Forms.TextBox textBox_NomeComputador;
        private System.Windows.Forms.Label label_NomeComputador;
        public System.Windows.Forms.TextBox textBox_NomeServico;
        private System.Windows.Forms.Label label_NomeServico;
        private System.Windows.Forms.Button button_Reinicia_Servico;
        private System.Windows.Forms.Button button_LimpaMensagens;
        private System.Windows.Forms.Button button_ReativaServico;
        private System.Windows.Forms.Timer timer_VerificaServidorAtivo;
        private System.Windows.Forms.CheckBox checkBox_Checando_Recurso_Monitorado;
    }
}

