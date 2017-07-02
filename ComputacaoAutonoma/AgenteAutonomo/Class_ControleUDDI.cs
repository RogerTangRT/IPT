using ClassLibrary_UDDI;
using System;
using System.Windows.Forms;

namespace AgenteAutonomo
{
    /// <summary>
    /// Simulador do UDDI.  Esta classe está relacionada com a interface
    /// </summary>
    public class Class_ControleUDDI
    {
        #region Variáveis
        /// <summary>
        /// Encapsula a classe UDDI
        /// </summary>
        Class_UDDI cls_UDDI = null;
        #endregion

        #region Propriedaes
        /// <summary>
        /// Retorna o Servidor Atual
        /// </summary>
        public String ServidorAtual
        {
            get { return cls_UDDI.ServidorAtual; }
        }
        /// <summary>
        /// Obtém próximo servidor
        /// </summary>
        /// <returns></returns>
        public String ObtemProximoServidor()
        {
            return cls_UDDI.ObtemProximaURL();
        }
        #endregion
        /// <summary>
        /// Construtor. Efetua as ligações
        /// </summary>
        /// <param name="UDDI">Classe UDDI</param>
        /// <param name="listBoxUDDI">ListBox contendo valores do UDDI</param>
        public Class_ControleUDDI(Class_UDDI UDDI, ListBox listBoxUDDI)
        {
            cls_UDDI = UDDI;
            PreencheListBox(listBoxUDDI);
        }
        /// <summary>
        /// Preenche lista
        /// </summary>
        /// <param name="listBoxUDDI">ListBox contendo valores do UDDI</param>
        private void PreencheListBox(ListBox listBoxUDDI)
        {
            cls_UDDI.Contador = 0;
            String url = cls_UDDI.ServidorAtual;
            String urlnova = url;
            do
            {
                url = urlnova;
                listBoxUDDI.Items.Add(url);
                urlnova = cls_UDDI.ObtemProximaURL();
            } while (url != urlnova);
            cls_UDDI.Contador = 0;
        }
    }
}
