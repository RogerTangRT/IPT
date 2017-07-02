using AgenteMonitorRecurso.Properties;
using System;
using System.ServiceProcess;

namespace AgenteMonitorRecurso.Servicos
{
    public class Service_Gerenciador_Recurso : IService_Gerenciador_Recurso
    {
        const UInt32 NAO_E_POSSIVEL_PARAR_SERVICO = 0x80131509;

        public String ReiniciaServico(String sNomeServico, String sNomeMaquina, int iTimeoutMilliseconds)
        {
            // Grava nos controles o nome do computador e o nome do serviço
            Class_Ponteiro_Form.Formulario.textBox_NomeComputador.Text = sNomeMaquina;
            Class_Ponteiro_Form.Formulario.textBox_NomeServico.Text = sNomeServico;

            ServiceController service = new ServiceController(sNomeServico, sNomeMaquina);
            Class_Timer cls_Timer = new Class_Timer(iTimeoutMilliseconds);
            String msg = String.Format(Resources.ResourceManager.GetString("SERVIDOR_REINICIADO"), sNomeMaquina);
            try
            {
                Class_Ponteiro_Form.Formulario.cls_InterfaceMensagem.Recebe(String.Format(Resources.ResourceManager.GetString("RECEBENDO_MENSAGEM"), sNomeServico, sNomeMaquina));
                cls_Timer.RegisterTime();
                Class_Ponteiro_Form.Formulario.cls_InterfaceMensagem.Log(Resources.ResourceManager.GetString("PARANDO_SERVIDOR"));
                service.Stop();
                service.WaitForStatus(ServiceControllerStatus.Stopped, cls_Timer.Timeout);

                cls_Timer.RegisterTime();
                Class_Ponteiro_Form.Formulario.cls_InterfaceMensagem.Log(Resources.ResourceManager.GetString("INICIANDO_SERVIDOR"));
                service.Start();
                service.WaitForStatus(ServiceControllerStatus.Running, cls_Timer.Timeout);

                Class_Ponteiro_Form.Formulario.cls_InterfaceMensagem.Envia(msg);
                return msg;
            }
            catch (Exception ex)
            {
                if ((UInt32)ex.HResult != NAO_E_POSSIVEL_PARAR_SERVICO)
                {
                    Class_Ponteiro_Form.Formulario.cls_InterfaceMensagem.Log((Resources.ResourceManager.GetString("TENTE_EXECUTAR_COMO_ADMINISTRADOR")));
                    String msgErro = "Erro:" + ex.Message + "\nHResult:" + String.Format("#{0:X}", ex.HResult);
                    Class_Ponteiro_Form.Formulario.cls_InterfaceMensagem.Envia(msgErro);
                    return msgErro;
                }
                else
                {
                    Class_Ponteiro_Form.Formulario.cls_InterfaceMensagem.Log(Resources.ResourceManager.GetString("SERVICO_JA_PARADO"));

                    try
                    {
                        cls_Timer.RegisterTime();
                        Class_Ponteiro_Form.Formulario.cls_InterfaceMensagem.Log(Resources.ResourceManager.GetString("INICIANDO_SERVIDOR"));
                        service.Start();
                        service.WaitForStatus(ServiceControllerStatus.Running, cls_Timer.Timeout);

                        Class_Ponteiro_Form.Formulario.cls_InterfaceMensagem.Envia(msg);
                        return msg;
                    }
                    catch (Exception exception)
                    {
                        String msgErro = "Erro:" + exception.Message;
                        Class_Ponteiro_Form.Formulario.cls_InterfaceMensagem.Envia(msgErro);
                        Class_Ponteiro_Form.Formulario.LigaTimerServidorAtivo(sNomeMaquina, sNomeServico);
                        return msgErro;
                    }
                }
            }
        }
    }
}
