using ClassLibrary_UDDI;
using System;

namespace AgenteAutonomo.Agente
{
    public class Class_Agente : Class_AgenteBase
    {
        #region Variáveis
        /// <summary>
        /// Classe de servidores.
        /// </summary>
        Class_Servidores cls_Servidores = null;
        #endregion

        #region Propriedades
        Class_Atuador cls_Atuador { get; set; }
        public Class_Sensor cls_Sensor { get; set; }

        public Class_Servidores Servidores
        {
            get { return cls_Servidores; }
        }
        #endregion
        public void GravaErro(String sMensgem)
        {
            cls_Servidores.GravaErro(sMensgem);
        }
        public Class_Agente(Class_UDDI UDDI, Class_Atuador atuador, Class_Sensor sensor)
        {
            cls_Servidores = new Class_Servidores(UDDI);

            cls_Atuador = atuador;
            cls_Sensor = sensor;
            sensor.cls_Agente = this;
            atuador.cls_Agente = this;
            cls_Sensor.cls_Atuador = atuador;
        }

        public String Reinicia(string computador, string servico)
        {
            cls_Sensor.Reinicia(computador, servico);
            bool chamaRecurso = false;
            string retorno = cls_Servidores.ProcessaReinicio(out chamaRecurso);
            // Computador foi reativado
            if (chamaRecurso && Computador != cls_Servidores.ComputadorAtual)
            {
                return cls_Atuador.EnviaServidorRecuperado(cls_Servidores.ComputadorAtual);
            }
            else
                return cls_Atuador.EnviaMensagemAgenteMonitorRecurso(chamaRecurso);
        }
        public void ReiniciaProcessaRetorno(string str)
        {
            try
            {
                cls_Atuador.Formulario.cls_InteraceMensagem.Recebe(str);
                cls_Atuador.Formulario.cls_InteraceMensagem.Envia(str);

                if (!cls_Atuador.cls_Agente.cls_Servidores.ProcessaRetornoReinicio(str))
                {
                    cls_Atuador.RetornoRespostaAgente.RetornaOrquestrador(str, true, cls_Atuador.Acessa_UDDI());
                }
                else
                {
                    cls_Atuador.RetornoRespostaAgente.RetornaOrquestrador(str, false, cls_Atuador.cls_Agente.cls_Servidores.cls_UDDI.ServidorAtual);
                }
            }
            catch (Exception ex)
            {
                cls_Atuador.Formulario.cls_InteraceMensagem.Log(ex.Message);
                cls_Atuador.RetornoRespostaAgente.RetornaOrquestrador(ex.Message, true, cls_Atuador.Acessa_UDDI());
            }
        }
    }
}
