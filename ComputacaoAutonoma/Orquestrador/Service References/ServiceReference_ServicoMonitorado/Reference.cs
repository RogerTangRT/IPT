﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Orquestrador.ServiceReference_ServicoMonitorado {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference_ServicoMonitorado.IService_Monitorado")]
    public interface IService_Monitorado {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService_Monitorado/ObtemNomeMaquina", ReplyAction="http://tempuri.org/IService_Monitorado/ObtemNomeMaquinaResponse")]
        string ObtemNomeMaquina();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService_Monitorado/ObtemNomeMaquina", ReplyAction="http://tempuri.org/IService_Monitorado/ObtemNomeMaquinaResponse")]
        System.Threading.Tasks.Task<string> ObtemNomeMaquinaAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService_Monitorado/ObtemListaIP", ReplyAction="http://tempuri.org/IService_Monitorado/ObtemListaIPResponse")]
        string[] ObtemListaIP();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService_Monitorado/ObtemListaIP", ReplyAction="http://tempuri.org/IService_Monitorado/ObtemListaIPResponse")]
        System.Threading.Tasks.Task<string[]> ObtemListaIPAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService_MonitoradoChannel : Orquestrador.ServiceReference_ServicoMonitorado.IService_Monitorado, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service_MonitoradoClient : System.ServiceModel.ClientBase<Orquestrador.ServiceReference_ServicoMonitorado.IService_Monitorado>, Orquestrador.ServiceReference_ServicoMonitorado.IService_Monitorado {
        
        public Service_MonitoradoClient() {
        }
        
        public Service_MonitoradoClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service_MonitoradoClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service_MonitoradoClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service_MonitoradoClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string ObtemNomeMaquina() {
            return base.Channel.ObtemNomeMaquina();
        }
        
        public System.Threading.Tasks.Task<string> ObtemNomeMaquinaAsync() {
            return base.Channel.ObtemNomeMaquinaAsync();
        }
        
        public string[] ObtemListaIP() {
            return base.Channel.ObtemListaIP();
        }
        
        public System.Threading.Tasks.Task<string[]> ObtemListaIPAsync() {
            return base.Channel.ObtemListaIPAsync();
        }
    }
}
