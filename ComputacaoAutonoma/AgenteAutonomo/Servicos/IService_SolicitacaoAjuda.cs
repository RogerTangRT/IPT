using System;
using System.ServiceModel;

namespace AgenteAutonomo.Servicos
{
    /// <summary>
    /// Interface WCF de Solicitação de Ajuda
    /// </summary>
    [ServiceContract]
    interface IService_SolicitacaoAjuda
    {
        /// <summary>
        /// Reinicia Hospedeiro
        /// </summary>
        /// <param name="sNomeComputador">Nome do computador</param>
        /// <param name="sNomeServico">Nome do Serviço</param>
        /// <returns></returns>
        [OperationContract]
        string ReiniciaHospedeiro(String sNomeComputador, String sNomeServico);

        /// <summary>
        /// ReiniciaContadores
        /// </summary>
        [OperationContract]
        void ReiniciaContadores();

        [OperationContract]
        void ServicoReativado(String sNomeComputador);

    }
}
