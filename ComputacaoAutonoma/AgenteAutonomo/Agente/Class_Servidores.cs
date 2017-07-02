using ClassLibrary_UDDI;
using System;

namespace AgenteAutonomo.Agente
{
    #region Classe Servidor
    class Class_Servidor
    {
        public int Solicitacoes { get; set; } = 0 ;
        public String Erro { get; set; } = "";
        public String NomeComputador { get; set; }
    }
    #endregion
    /// <summary>
    /// Classe utilizada para gerenciar o estado de erro de cada servidor.
    /// Esta classe é utilizada para deliberação do agente.
    /// </summary>
    public class Class_Servidores
    {
        #region Variáveis
        /// <summary>
        /// Lista de servidores
        /// </summary>
        Class_Servidor[] arr_cls_servidores;
        #endregion

        #region Propriedades
        /// <summary>
        /// Número máximo de servidores. Usado para alocação do Array de servidore
        /// </summary>
        int MAX_SERVIDORES { get; set; }
        /// <summary>
        /// Classe UDDI. Para cada elemento do UDDI deverá ter uma entrada no array para efetuar o controle
        /// </summary>
        public Class_UDDI cls_UDDI { get; set; }

        public String ComputadorAtual { get { return arr_cls_servidores[cls_UDDI.Contador].NomeComputador; } }
        #endregion
        /// <summary>
        /// Contrutor. Inicializa os servidores
        /// </summary>
        /// <param name="UDDI">Classe UDDI</param>
        public Class_Servidores(Class_UDDI UDDI)
        {
            cls_UDDI = UDDI;
            IniciaServidores();
        }
        /// <summary>
        /// Inicializa os servidores. Efetua a alocação e inicialização
        /// </summary>
        private void IniciaServidores()
        {
            MAX_SERVIDORES = cls_UDDI.NumElementos;
            arr_cls_servidores = new Class_Servidor[MAX_SERVIDORES];
            for (int i = 0; i < MAX_SERVIDORES; i++)
            {
                arr_cls_servidores[i] = new Class_Servidor();
                arr_cls_servidores[i].NomeComputador = cls_UDDI[i];
            }
        }
        /// <summary>
        /// Reinicia os contadores. Se algum servidor estiver em estado de erro, este contador será zerado.
        /// </summary>
        public void ReiniciaContadorServidores()
        {
            foreach (var servidor in arr_cls_servidores)
            {
                servidor.Solicitacoes = 0;
                servidor.Erro = "";
            }
            cls_UDDI.Contador = 0;

        }
        public void GravaErro(String sMensgem)
        {
            arr_cls_servidores[cls_UDDI.Contador].Erro = sMensgem;
        }
        /// <summary>
        /// Quando a Agente monitor de recurso retorna. Esta função serve para processar o retorno. Se ocorreu algum erro 
        /// este erro é registrado
        /// </summary>
        /// <param name="sMensgem">Mensgaem vinda do Agente Monitor de Recurso</param>
        /// <returns></returns>
        public Boolean ProcessaRetornoReinicio(String sMensgem)
        {
            if (sMensgem.IndexOf("Erro") != -1)
            {
                arr_cls_servidores[cls_UDDI.Contador].Erro = sMensgem;
                return false;
            }
            else
            {
                if (arr_cls_servidores[cls_UDDI.Contador].Solicitacoes > 0)
                    arr_cls_servidores[cls_UDDI.Contador].Solicitacoes--;

                arr_cls_servidores[cls_UDDI.Contador].Erro = "";
                return true;
            }
        }
        public void ReativaServico(String sComputador)
        {
            for(int i=0;i< MAX_SERVIDORES; i++)
            {
                if(sComputador.ToUpper() == arr_cls_servidores[i].NomeComputador.ToUpper())
                {
                    arr_cls_servidores[i].Erro = "";
                }
            }
        }
        /// <summary>
        /// Processa o Reinício.Caso o servidor atual estriver em estado de erro. Chaveia para o próximo servidor
        /// </summary>
        /// <param name="chamaRecurso"></param>
        /// <returns></returns>
        public String ProcessaReinicio(out bool chamaRecurso)
        {
            chamaRecurso = false;

            if (arr_cls_servidores[cls_UDDI.Contador].Erro == "" && arr_cls_servidores[cls_UDDI.Contador].Solicitacoes == 0)
            {
                arr_cls_servidores[cls_UDDI.Contador].Solicitacoes++;
                chamaRecurso = true;
            }
            else
            {
                for(int i=0;i< MAX_SERVIDORES;i++)
                {
                    if(arr_cls_servidores[i].Erro == "")
                    {
                        arr_cls_servidores[i].Solicitacoes = 0;
                        cls_UDDI.Contador = i;
                        chamaRecurso = true;
                    }
                }
            }
            return arr_cls_servidores[cls_UDDI.Contador].Erro;
        }
    }
}
