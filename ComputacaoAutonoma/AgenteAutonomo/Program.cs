using System;
using System.Windows.Forms;

namespace AgenteAutonomo
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada da aplicação
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form_AgenteAutonomo());
        }
    }
}
