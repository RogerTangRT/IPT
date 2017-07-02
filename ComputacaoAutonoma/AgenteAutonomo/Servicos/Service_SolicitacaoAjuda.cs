using AgenteAutonomo.Properties;
using System;

namespace AgenteAutonomo.Servicos
{
    /// <summary>
    /// Interface de recebimento de mensagens WCF vindas do Orquestrador
    /// </summary>
    class Service_SolicitacaoAjuda : IService_SolicitacaoAjuda
    {
        /// <summary>
        /// Reinicia Hopedeiro
        /// </summary>
        /// <param name="sNomeComputador">Nome do Computador</param>
        /// <param name="sNomeServico">Nome do Serviço</param>
        /// <returns></returns>
        public String ReiniciaHospedeiro(String sNomeComputador, String sNomeServico)
        {
            Class_Ponteiro_Form.Formulario.Recebe((String.Format(Resources.ResourceManager.GetString("RECEBENDO_MENSAGEM"), sNomeComputador, sNomeServico)));
            return Class_Ponteiro_Form.Formulario.Reinicia(sNomeComputador, sNomeServico);
        }
        /// <summary>
        /// Função para pelo Orquestrador para reinício dos contadres
        /// </summary>
        public void ReiniciaContadores()
        {
            Class_Ponteiro_Form.Formulario.ReiniciaContadores();
        }
        /// <summary>
        /// Interface utilizada pelo agente monitor de Recurs para indicar que um serviço foi retivado
        /// </summary>
        /// <param name="sComputador">Nome do computador</param>
        public void ServicoReativado(String sNomeComputador)
        {
            Class_Ponteiro_Form.Formulario.Recebe((String.Format("Serviço reativado pelo computador [{0}]", sNomeComputador)));
            Class_Ponteiro_Form.Formulario.ServicoReativado(sNomeComputador);
        }
    }
}
