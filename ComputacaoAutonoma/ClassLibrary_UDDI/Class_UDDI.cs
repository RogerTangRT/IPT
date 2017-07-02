using System;
using System.Collections.Generic;
using System.Data;

namespace ClassLibrary_UDDI
{
    public class Class_UDDI
    {
        #region Variáveis
        List<String> lst_Lista_UDDI = new List<String>();
        #endregion

        #region Propriedades
        public String this[int i]
        {
            get { return lst_Lista_UDDI[i]; }
        }
        public int Contador { get; set; }
        /// <summary>
        /// Armazena o número de elementos da lista
        /// </summary>
        public int NumElementos { get; set; }

        /// <summary>
        /// Obtem o nome do servidor atual
        /// </summary>
        public String ServidorAtual
        {
            get { return lst_Lista_UDDI[Contador]; }
        }
        #endregion

        /// <summary>
        /// Construtor. Lê o arguivo de configuração XMLFile_UDDI.xml e inicializa a lista
        /// </summary>
        public Class_UDDI()
        {
            DataSet ds = new DataSet();
            ds.ReadXml(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\..\\ClassLibrary_UDDI\\XMLFile_UDDI.xml");
            DataTable tb = ds.Tables[0];

            foreach (DataRow linha in tb.Rows)
            {
                lst_Lista_UDDI.Add(linha[0].ToString());
                NumElementos++;
            }
        }
       
        /// <summary>
        /// Obtém próximo servidor da lista
        /// </summary>
        /// <returns></returns>
        public String ObtemProximaURL()
        {
            if (Contador < lst_Lista_UDDI.Count - 1)
                Contador++;

            String url = lst_Lista_UDDI[Contador];

            return url;
        }
    }
}
