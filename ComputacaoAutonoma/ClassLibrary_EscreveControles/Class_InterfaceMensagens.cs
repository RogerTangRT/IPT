using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClassLibrary_Mensagens
{
    /// <summary>
    /// Esta classe serva para escreve nos controles dentro do contexto de outra thread
    /// </summary>
    public class Class_InterfaceMensagens
    {
        #region Variáveis
        /// <summary>
        /// Classe para escrita nos controles
        /// </summary>
        Class_EscreveControles cls_EscreveControles = new Class_EscreveControles();
        /// <summary>
        /// Mensagens Enviadas
        /// </summary>
        RichTextBox RichTextBox_Enviadas = null;
        /// <summary>
        /// Mensagens Recebidas
        /// </summary>
        RichTextBox RichTextBox_Recebidas = null;
        /// <summary>
        /// Mensagens Internas ou de Log
        /// </summary>
        RichTextBox RichTextBox_Internas = null;
        Form Formulario = null;
        #endregion

        /// <summary>
        /// Contrutor
        /// </summary>
        /// <param name="richTextBox_Enviadas">Controle das mensagens Enviadas</param>
        /// <param name="richTextBox_Recebidas">Controle das mensagens Recebinas</param>
        /// <param name="richTextBox_Internas">Controle das mensagens Internas</param>
        /// <param name="formulario">Ponteiro para o Formulário</param>
        public Class_InterfaceMensagens(
            RichTextBox richTextBox_Enviadas,
            RichTextBox richTextBox_Recebidas,
            RichTextBox richTextBox_Internas,
            Form formulario)
        {
            RichTextBox_Enviadas = richTextBox_Enviadas;
            RichTextBox_Recebidas = richTextBox_Recebidas;
            RichTextBox_Internas = richTextBox_Internas;
            Formulario = formulario;
        }
        /// <summary>
        /// Reinicia contador de mensagens
        /// </summary>
        public void ReiniciaContador()
        {
            cls_EscreveControles.ReiniciaContador();
        }
        /// <summary>
        /// Grava(concatena) no controle de enviadas
        /// </summary>
        /// <param name="sMensagem"></param>
        public void Envia(String sMensagem)
        {
            cls_EscreveControles.AnexaRitchText(sMensagem, RichTextBox_Enviadas, Formulario);
        }
        /// <summary>
        /// Grava(concatena) no controle de recedidas
        /// </summary>
        /// <param name="sMensagem"></param>
        public void Recebe(String sMensagem)
        {
            cls_EscreveControles.AnexaRitchText(sMensagem, RichTextBox_Recebidas, Formulario);
        }
        /// <summary>
        /// Grava(concatena) no controle de Internas ou log
        /// </summary>
        /// <param name="sMensagem"></param>
        public void Log(String sMensagem)
        {
            cls_EscreveControles.AnexaRitchText(sMensagem, RichTextBox_Internas, Formulario);
        }
        /// <summary>
        /// Apaga RichTextBox
        /// </summary>
        /// <param name="richTextBoxProcessoIP"></param>
        public void Apaga(RichTextBox richTextBoxProcessoIP)
        {
            cls_EscreveControles.ApagaRitchText(richTextBoxProcessoIP, Formulario);
        }
        /// <summary>
        /// Escreve no RichTextBox.  Usado para o processo 2
        /// </summary>
        /// <param name="sMensagem"></param>
        /// <param name="richTextBoxProcessoIP"></param>
        public void Escreve(String sMensagem, RichTextBox richTextBoxProcessoIP)
        {
            cls_EscreveControles.AnexaRitchText(sMensagem,richTextBoxProcessoIP, Formulario);
        }
        /// <summary>
        /// Escreve no textbox. Usado para o nome da máquina e o nome do serviço
        /// </summary>
        /// <param name="sMensagem"></param>
        /// <param name="TextBoxProcessoIP"></param>
        public void EscreveTextBox(String sMensagem, TextBox TextBoxProcessoIP)
        {
            cls_EscreveControles.EscreveTextBox(sMensagem, TextBoxProcessoIP, Formulario);
        }
        /// <summary>
        /// Altera a cor do controle
        /// </summary>
        /// <param name="cor"></param>
        /// <param name="textbox"></param>
        public void AlteraCor(Color cor,TextBox textbox)
        {
            cls_EscreveControles.AlteraCorTextBox(cor, textbox, Formulario);
        }
    }

}
