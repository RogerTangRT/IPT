using Orquestrador.ServiceReference_RespostaAgente;
using System;
using System.ServiceModel;
using System.Threading;

namespace Orquestrador
{
    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant, UseSynchronizationContext = false)]
    class Class_Resposta_AgenteAutonomo : IService_RespostaAgenteCallback
    {
        #region Propriedades
        /// <summary>
        /// Ponteiro para classe de Mensagens. Retorna paramesma classe que enviou a mensagem
        /// </summary>
        public Class_Mensagens cls_Mensagem { get; set; }
        #endregion
        /// <summary>
        /// Callback de Resposta
        /// </summary>
        /// <param name="sMensagem">Mensagem</param>
        /// <param name="bErro">Se a mensagem é de erro</param>
        /// <param name="sServidorAlternativo">Servidor alternativo</param>
        public void Responde(String sMensagem, Boolean bErro, String sServidorAlternativo)
        {
            if (cls_Mensagem != null)
            {
                new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;
                    cls_Mensagem.Callback_RetomaProcesso(sMensagem, bErro, sServidorAlternativo);
                }).Start();

            }
        }
    }
}
