﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Orquestrador.ServiceReference_GerenciadorCor {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference_GerenciadorCor.IService_GerenciadorCor")]
    public interface IService_GerenciadorCor {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService_GerenciadorCor/ObtemCor", ReplyAction="http://tempuri.org/IService_GerenciadorCor/ObtemCorResponse")]
        GerenciadorCor.Cor ObtemCor();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService_GerenciadorCor/ObtemCor", ReplyAction="http://tempuri.org/IService_GerenciadorCor/ObtemCorResponse")]
        System.Threading.Tasks.Task<GerenciadorCor.Cor> ObtemCorAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService_GerenciadorCorChannel : Orquestrador.ServiceReference_GerenciadorCor.IService_GerenciadorCor, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service_GerenciadorCorClient : System.ServiceModel.ClientBase<Orquestrador.ServiceReference_GerenciadorCor.IService_GerenciadorCor>, Orquestrador.ServiceReference_GerenciadorCor.IService_GerenciadorCor {
        
        public Service_GerenciadorCorClient() {
        }
        
        public Service_GerenciadorCorClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service_GerenciadorCorClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service_GerenciadorCorClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service_GerenciadorCorClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public GerenciadorCor.Cor ObtemCor() {
            return base.Channel.ObtemCor();
        }
        
        public System.Threading.Tasks.Task<GerenciadorCor.Cor> ObtemCorAsync() {
            return base.Channel.ObtemCorAsync();
        }
    }
}