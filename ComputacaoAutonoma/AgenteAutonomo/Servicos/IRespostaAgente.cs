using System;
using System.ServiceModel;

namespace AgenteAutonomo.Servicos
{
    public interface IRespostaAgente
    {
        [OperationContract]
        void Responde(String sMensagem, Boolean bErro, String sServidorAlternativo);
    }
}
