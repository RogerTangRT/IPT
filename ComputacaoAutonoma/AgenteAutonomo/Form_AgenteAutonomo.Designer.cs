namespace AgenteAutonomo
{
    partial class Form_AgenteAutonomo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_AgenteAutonomo));
            this.groupBox_Mensagens = new System.Windows.Forms.GroupBox();
            this.richTextBox_Enviadas = new System.Windows.Forms.RichTextBox();
            this.label_Enviadas = new System.Windows.Forms.Label();
            this.richTextBox_Internas = new System.Windows.Forms.RichTextBox();
            this.label_Internas = new System.Windows.Forms.Label();
            this.label_Recebidas = new System.Windows.Forms.Label();
            this.richTextBox_Recebidas = new System.Windows.Forms.RichTextBox();
            this.groupBox_Controles = new System.Windows.Forms.GroupBox();
            this.button_Reinicializa_Agentes = new System.Windows.Forms.Button();
            this.button_ReativaServico = new System.Windows.Forms.Button();
            this.label_Ordem_UDDI = new System.Windows.Forms.Label();
            this.listBoxUDDI = new System.Windows.Forms.ListBox();
            this.textBox_NomeComputador = new System.Windows.Forms.TextBox();
            this.label_NomeComputador = new System.Windows.Forms.Label();
            this.textBox_NomeServico = new System.Windows.Forms.TextBox();
            this.label_NomeServico = new System.Windows.Forms.Label();
            this.button_Reinicia_Servico = new System.Windows.Forms.Button();
            this.button_LimpaMensagens = new System.Windows.Forms.Button();
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
            this.groupBox_Mensagens.TabIndex = 3;
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
            this.groupBox_Controles.Controls.Add(this.button_Reinicializa_Agentes);
            this.groupBox_Controles.Controls.Add(this.button_ReativaServico);
            this.groupBox_Controles.Controls.Add(this.label_Ordem_UDDI);
            this.groupBox_Controles.Controls.Add(this.listBoxUDDI);
            this.groupBox_Controles.Controls.Add(this.textBox_NomeComputador);
            this.groupBox_Controles.Controls.Add(this.label_NomeComputador);
            this.groupBox_Controles.Controls.Add(this.textBox_NomeServico);
            this.groupBox_Controles.Controls.Add(this.label_NomeServico);
            this.groupBox_Controles.Controls.Add(this.button_Reinicia_Servico);
            this.groupBox_Controles.Controls.Add(this.button_LimpaMensagens);
            this.groupBox_Controles.Location = new System.Drawing.Point(638, 13);
            this.groupBox_Controles.Name = "groupBox_Controles";
            this.groupBox_Controles.Size = new System.Drawing.Size(244, 540);
            this.groupBox_Controles.TabIndex = 4;
            this.groupBox_Controles.TabStop = false;
            this.groupBox_Controles.Text = "Controles";
            // 
            // button_Reinicializa_Agentes
            // 
            this.button_Reinicializa_Agentes.Location = new System.Drawing.Point(9, 67);
            this.button_Reinicializa_Agentes.Name = "button_Reinicializa_Agentes";
            this.button_Reinicializa_Agentes.Size = new System.Drawing.Size(228, 23);
            this.button_Reinicializa_Agentes.TabIndex = 9;
            this.button_Reinicializa_Agentes.Text = "Reinicializa Agentes";
            this.button_Reinicializa_Agentes.UseVisualStyleBackColor = true;
            this.button_Reinicializa_Agentes.Click += new System.EventHandler(this.button_Reinicializa_Agentes_Click);
            // 
            // button_ReativaServico
            // 
            this.button_ReativaServico.Location = new System.Drawing.Point(8, 127);
            this.button_ReativaServico.Name = "button_ReativaServico";
            this.button_ReativaServico.Size = new System.Drawing.Size(230, 23);
            this.button_ReativaServico.TabIndex = 8;
            this.button_ReativaServico.Text = "Reativa Serviço";
            this.button_ReativaServico.UseVisualStyleBackColor = true;
            this.button_ReativaServico.Click += new System.EventHandler(this.button_ReativaServico_Click);
            // 
            // label_Ordem_UDDI
            // 
            this.label_Ordem_UDDI.AutoSize = true;
            this.label_Ordem_UDDI.Location = new System.Drawing.Point(6, 270);
            this.label_Ordem_UDDI.Name = "label_Ordem_UDDI";
            this.label_Ordem_UDDI.Size = new System.Drawing.Size(68, 13);
            this.label_Ordem_UDDI.TabIndex = 7;
            this.label_Ordem_UDDI.Text = "Ordem UDDI";
            // 
            // listBoxUDDI
            // 
            this.listBoxUDDI.FormattingEnabled = true;
            this.listBoxUDDI.Location = new System.Drawing.Point(9, 286);
            this.listBoxUDDI.Name = "listBoxUDDI";
            this.listBoxUDDI.Size = new System.Drawing.Size(229, 82);
            this.listBoxUDDI.TabIndex = 6;
            // 
            // textBox_NomeComputador
            // 
            this.textBox_NomeComputador.Location = new System.Drawing.Point(9, 227);
            this.textBox_NomeComputador.Name = "textBox_NomeComputador";
            this.textBox_NomeComputador.Size = new System.Drawing.Size(230, 20);
            this.textBox_NomeComputador.TabIndex = 5;
            // 
            // label_NomeComputador
            // 
            this.label_NomeComputador.AutoSize = true;
            this.label_NomeComputador.Location = new System.Drawing.Point(6, 211);
            this.label_NomeComputador.Name = "label_NomeComputador";
            this.label_NomeComputador.Size = new System.Drawing.Size(95, 13);
            this.label_NomeComputador.TabIndex = 4;
            this.label_NomeComputador.Text = "Nome Computador";
            // 
            // textBox_NomeServico
            // 
            this.textBox_NomeServico.Location = new System.Drawing.Point(9, 184);
            this.textBox_NomeServico.Name = "textBox_NomeServico";
            this.textBox_NomeServico.Size = new System.Drawing.Size(230, 20);
            this.textBox_NomeServico.TabIndex = 3;
            this.textBox_NomeServico.Text = "Servico Monitorado";
            // 
            // label_NomeServico
            // 
            this.label_NomeServico.AutoSize = true;
            this.label_NomeServico.Location = new System.Drawing.Point(6, 168);
            this.label_NomeServico.Name = "label_NomeServico";
            this.label_NomeServico.Size = new System.Drawing.Size(89, 13);
            this.label_NomeServico.TabIndex = 2;
            this.label_NomeServico.Text = "Nome do Serviço";
            // 
            // button_Reinicia_Servico
            // 
            this.button_Reinicia_Servico.Location = new System.Drawing.Point(8, 98);
            this.button_Reinicia_Servico.Name = "button_Reinicia_Servico";
            this.button_Reinicia_Servico.Size = new System.Drawing.Size(229, 23);
            this.button_Reinicia_Servico.TabIndex = 1;
            this.button_Reinicia_Servico.Text = "Reiniciar Serviço";
            this.button_Reinicia_Servico.UseVisualStyleBackColor = true;
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
            // Form_AgenteAutonomo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.ClientSize = new System.Drawing.Size(906, 556);
            this.Controls.Add(this.groupBox_Controles);
            this.Controls.Add(this.groupBox_Mensagens);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_AgenteAutonomo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agente Autônomo";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_AgenteAutonomo_FormClosed);
            this.Load += new System.EventHandler(this.Form_AgenteAutonomo_Load);
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
        private System.Windows.Forms.Label label_Ordem_UDDI;
        public System.Windows.Forms.ListBox listBoxUDDI;
        public System.Windows.Forms.TextBox textBox_NomeComputador;
        private System.Windows.Forms.Label label_NomeComputador;
        public System.Windows.Forms.TextBox textBox_NomeServico;
        private System.Windows.Forms.Label label_NomeServico;
        private System.Windows.Forms.Button button_Reinicia_Servico;
        private System.Windows.Forms.Button button_LimpaMensagens;
        private System.Windows.Forms.Button button_ReativaServico;
        private System.Windows.Forms.Button button_Reinicializa_Agentes;
    }
}

