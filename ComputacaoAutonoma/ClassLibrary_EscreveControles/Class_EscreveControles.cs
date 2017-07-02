using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClassLibrary_Mensagens
{
    public class Class_EscreveControles
    {
        #region RitchText

        #region Contador
        /// <summary>
        /// Contador de mensagens
        /// </summary>
        static int i_Contador = 1;

        /// <summary>
        /// Reinicia o contador dos itens escritos nos listbox.
        /// A casa mensagem escrita em um dos list box um contador é incrementado
        /// </summary>
        public void ReiniciaContador()
        {
            i_Contador = 1;
        }
        #endregion

        #region Escreve no RitchText
        /// <summary>
        /// Delegate para anexar no RitchText
        /// </summary>
        /// <param name="s_Mensagem">Mensagem a ser escrita</param>
        /// <param name="controle">Controle</param>
        delegate void delegateAnexaRitchText(String s_Mensagem, Control controle);
        /// <summary>
        /// Anexa no controle RitchTex. Este método é chamado quando está sendo chamado no contexto de outra tarefa
        /// </summary>
        /// <param name="s_Mensagem">Mensagem a ser escrita</param>
        /// <param name="controle">Controle</param>
        private void AnexaControleRitchText(String s_Mensagem, Control controle)
        {
            string sMsgFinal;
            if (((RichTextBox)(controle)).Text == "")
                sMsgFinal = s_Mensagem;
            else
                sMsgFinal = "\n" + s_Mensagem;

            ((RichTextBox)(controle)).AppendText(sMsgFinal);
            ((RichTextBox)(controle)).Refresh();
        }
        /// <summary>
        /// Anexa mensagem no RitchText
        /// </summary>
        /// <param name="s_Mensagem">Mensagem a ser escrita</param>
        /// <param name="controle">Controle</param>
        /// <param name="formulario">Ponteiro para o formulário</param>
        public void AnexaRitchText(String s_Mensagem, Control controle, Form formulario)
        {
            s_Mensagem = "[" + (i_Contador++).ToString("000") + "] " + s_Mensagem;
            if (formulario.InvokeRequired)
                formulario.Invoke(new delegateAnexaRitchText(AnexaControleRitchText), s_Mensagem, controle);
            else
            {
                string sMensagemFinal;
                if (((RichTextBox)(controle)).Text == "")
                    sMensagemFinal = s_Mensagem;
                else
                    sMensagemFinal = "\n" + s_Mensagem;

                ((RichTextBox)(controle)).AppendText(sMensagemFinal);
                ((RichTextBox)(controle)).Refresh();
            }
        }
        #endregion

        #region Apaga RitchText
        /// <summary>
        /// Delegate Apaga RitchText
        /// </summary>
        /// <param name="controle">Controle</param>
        delegate void delegateApagaRitchText(Control controle);
        /// <summary>
        /// Apaga conteúdo do RitchText.Este método é chamado quando está sendo chamado no contexto de outra tarefa
        /// </summary>
        /// <param name="controle">Controle</param>
        private void ApagaControleRitchText(Control controle)
        {
            ((RichTextBox)(controle)).Clear();
            ((RichTextBox)(controle)).Refresh();
        }
        /// <summary>
        /// Apaga RitchText
        /// </summary>
        /// <param name="controle">Controle</param>
        /// <param name="formulario">Formulário</param>
        public void ApagaRitchText(Control controle, Form formulario)
        {
            if (formulario.InvokeRequired)

                formulario.Invoke(new delegateApagaRitchText(ApagaControleRitchText), controle);
            else
            {
                ((RichTextBox)(controle)).Clear();
                ((RichTextBox)(controle)).Refresh();
            }
        }
        #endregion

        #endregion

        #region TextBox
        /// <summary>
        /// Delegate para alterar a cor do textbox
        /// </summary>
        /// <param name="cor">Cor</param>
        /// <param name="controle">Controle</param>
        delegate void delegateAlteraCor(Color cor, Control controle);
        /// <summary>
        /// Alterar a cor do textbox.Este método é chamado quando está sendo chamado no contexto de outra tarefa
        /// </summary>
        /// <param name="cor">Cor</param>
        /// <param name="controle">Controle</param>
        private void AlteraCorTextBox(Color cor, Control controle)
        {
            ((TextBox)(controle)).BackColor = cor;
            ((TextBox)(controle)).Refresh();
        }
        /// <summary>
        /// Alterar a cor do textbox.
        /// </summary>
        /// <param name="cor">Cor</param>
        /// <param name="controle">Controle</param>
        /// <param name="formulario">Ponteiro para o formulário</param>
        public void AlteraCorTextBox(Color cor, Control controle, Form formulario)
        {
            if (formulario.InvokeRequired)

                formulario.Invoke(new delegateAlteraCor(AlteraCorTextBox), cor, controle);
            else
            {
                ((TextBox)(controle)).BackColor = cor;
                ((TextBox)(controle)).Refresh();
            }
        }

        #endregion

        #region EscreveTextBox
        /// <summary>
        /// Delegate para escrever no richText
        /// </summary>
        /// <param name="s_Mensagem">Mensagem</param>
        /// <param name="controle">Controle</param>
        delegate void delegateEscreveTextBox(String s_Mensagem, Control controle);
        /// <summary>
        /// Escreve no controle textbox
        /// </summary>
        /// <param name="s_Mensagem">Mensagem</param>
        /// <param name="controle">Controle</param>
        private void EscreveControleTextBox(String s_Mensagem, Control controle)
        {
            ((TextBox)(controle)).Text = s_Mensagem;
            ((TextBox)(controle)).Refresh();
        }
        /// <summary>
        /// Escrebe no TextBox
        /// </summary>
        /// <param name="s_Mensagem">Mensagem</param>
        /// <param name="controle">Controle</param>
        /// <param name="formulario">Formulário</param>
        public void EscreveTextBox(String s_Mensagem, Control controle, Form formulario)
        {
            if (formulario.InvokeRequired)
                formulario.Invoke(new delegateEscreveTextBox(EscreveControleTextBox), s_Mensagem, controle);
            else
            {
                ((TextBox)(controle)).Text = s_Mensagem;
                ((TextBox)(controle)).Refresh();
            }
        }
        #endregion
    }
}
