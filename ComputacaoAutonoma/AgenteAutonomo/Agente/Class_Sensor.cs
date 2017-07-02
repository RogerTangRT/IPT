using System;

namespace AgenteAutonomo.Agente
{
    public class Class_Sensor
    {
        #region Propriedades
        /// <summary>
        /// Ponteiro para o Agente
        /// </summary>
        public Class_Agente cls_Agente { get; set; }
        /// <summary>
        /// Ponteiro para o Atuador
        /// </summary>
        public Class_Atuador cls_Atuador { get; set; }
        #endregion

        /// <summary>
        /// Mensagens Vindas do Orquestrador
        /// </summary>
        /// <param name="computador"></param>
        /// <param name="servico"></param>
        public void Reinicia(string computador, string servico)
        {
            cls_Agente.Computador = computador;
            cls_Agente.Servico = servico;
        }

        /// <summary>
        /// Mensagens vindas do Agente Monitor de Recurso
        /// </summary>
        /// <param name="result"></param>
        public void AsyncCallBack_ReiniciaServico(IAsyncResult result)
        {
            string str = "Erro";
            try
            {
                str = cls_Atuador.AgenteMonitorRecurso.EndReiniciaServico(result);
                cls_Agente.ReiniciaProcessaRetorno(str);
            }
            catch (Exception ex)
            {
                if (str == "Erro")
                {
                    if(!ex.Message.Contains(str))
                        cls_Agente.ReiniciaProcessaRetorno(str + ":" + ex.Message);
                    else
                        cls_Agente.ReiniciaProcessaRetorno(ex.Message);
                }
                else
                {
                    cls_Atuador.Formulario.cls_InteraceMensagem.Log(ex.Message);
                    cls_Atuador.RetornoRespostaAgente.RetornaOrquestrador(ex.Message, true, cls_Atuador.Acessa_UDDI());
                }
            }
        }
    }

}
