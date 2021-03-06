﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     //
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WSOrden
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.5.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.eam.edu.co", ConfigurationName="WSOrden.orderService")]
    public interface orderService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<WSOrden.programarenvioResponse> programarenvioAsync(WSOrden.programarenvio request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<WSOrden.ordenarResponse> ordenarAsync(WSOrden.ordenar request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.5.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.eam.edu.co")]
    public partial class shippingOrderConfirmation
    {
        
        private long idField;
        
        private shippingOrder shippingOrderField;
        
        private bool orderReceivedStatusField;
        
        private System.DateTime fechaEnvioField;
        
        private bool fechaEnvioFieldSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public long id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public shippingOrder shippingOrder
        {
            get
            {
                return this.shippingOrderField;
            }
            set
            {
                this.shippingOrderField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public bool orderReceivedStatus
        {
            get
            {
                return this.orderReceivedStatusField;
            }
            set
            {
                this.orderReceivedStatusField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public System.DateTime fechaEnvio
        {
            get
            {
                return this.fechaEnvioField;
            }
            set
            {
                this.fechaEnvioField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool fechaEnvioSpecified
        {
            get
            {
                return this.fechaEnvioFieldSpecified;
            }
            set
            {
                this.fechaEnvioFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.5.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.eam.edu.co")]
    public partial class shippingOrder
    {
        
        private int shippingIdField;
        
        private string mailField;
        
        private string cellNumberField;
        
        private string billingAddressField;
        
        private string shippingAddressField;
        
        private string organizationField;
        
        private string idOrderField;
        
        private orderItem[] orderField;
        
        private bool enviadaField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public int shippingId
        {
            get
            {
                return this.shippingIdField;
            }
            set
            {
                this.shippingIdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string mail
        {
            get
            {
                return this.mailField;
            }
            set
            {
                this.mailField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public string cellNumber
        {
            get
            {
                return this.cellNumberField;
            }
            set
            {
                this.cellNumberField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public string billingAddress
        {
            get
            {
                return this.billingAddressField;
            }
            set
            {
                this.billingAddressField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=4)]
        public string shippingAddress
        {
            get
            {
                return this.shippingAddressField;
            }
            set
            {
                this.shippingAddressField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=5)]
        public string organization
        {
            get
            {
                return this.organizationField;
            }
            set
            {
                this.organizationField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=6)]
        public string idOrder
        {
            get
            {
                return this.idOrderField;
            }
            set
            {
                this.idOrderField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=7)]
        [System.Xml.Serialization.XmlArrayItemAttribute("orderItemList", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public orderItem[] order
        {
            get
            {
                return this.orderField;
            }
            set
            {
                this.orderField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=8)]
        public bool enviada
        {
            get
            {
                return this.enviadaField;
            }
            set
            {
                this.enviadaField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.5.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.eam.edu.co")]
    public partial class orderItem
    {
        
        private string merchantSKUField;
        
        private int quantityField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string merchantSKU
        {
            get
            {
                return this.merchantSKUField;
            }
            set
            {
                this.merchantSKUField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public int quantity
        {
            get
            {
                return this.quantityField;
            }
            set
            {
                this.quantityField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.5.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="programarenvio", WrapperNamespace="http://www.eam.edu.co", IsWrapped=true)]
    public partial class programarenvio
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.eam.edu.co", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int idorden;
        
        public programarenvio()
        {
        }
        
        public programarenvio(int idorden)
        {
            this.idorden = idorden;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.5.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="programarenvioResponse", WrapperNamespace="http://www.eam.edu.co", IsWrapped=true)]
    public partial class programarenvioResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.eam.edu.co", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public WSOrden.shippingOrderConfirmation shipConfirmacion;
        
        public programarenvioResponse()
        {
        }
        
        public programarenvioResponse(WSOrden.shippingOrderConfirmation shipConfirmacion)
        {
            this.shipConfirmacion = shipConfirmacion;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.5.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ordenar", WrapperNamespace="http://www.eam.edu.co", IsWrapped=true)]
    public partial class ordenar
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.eam.edu.co", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public WSOrden.shippingOrder orden;
        
        public ordenar()
        {
        }
        
        public ordenar(WSOrden.shippingOrder orden)
        {
            this.orden = orden;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.5.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ordenarResponse", WrapperNamespace="http://www.eam.edu.co", IsWrapped=true)]
    public partial class ordenarResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.eam.edu.co", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string shipConfirmacion;
        
        public ordenarResponse()
        {
        }
        
        public ordenarResponse(string shipConfirmacion)
        {
            this.shipConfirmacion = shipConfirmacion;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.5.0.0")]
    public interface orderServiceChannel : WSOrden.orderService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.5.0.0")]
    public partial class orderServiceClient : System.ServiceModel.ClientBase<WSOrden.orderService>, WSOrden.orderService
    {
        
    /// <summary>
    /// Implement this partial method to configure the service endpoint.
    /// </summary>
    /// <param name="serviceEndpoint">The endpoint to configure</param>
    /// <param name="clientCredentials">The client credentials</param>
    static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public orderServiceClient() : 
                base(orderServiceClient.GetDefaultBinding(), orderServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.orderServicePort.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public orderServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(orderServiceClient.GetBindingForEndpoint(endpointConfiguration), orderServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public orderServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(orderServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public orderServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(orderServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public orderServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WSOrden.programarenvioResponse> WSOrden.orderService.programarenvioAsync(WSOrden.programarenvio request)
        {
            return base.Channel.programarenvioAsync(request);
        }
        
        public System.Threading.Tasks.Task<WSOrden.programarenvioResponse> programarenvioAsync(int idorden)
        {
            WSOrden.programarenvio inValue = new WSOrden.programarenvio();
            inValue.idorden = idorden;
            return ((WSOrden.orderService)(this)).programarenvioAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WSOrden.ordenarResponse> WSOrden.orderService.ordenarAsync(WSOrden.ordenar request)
        {
            return base.Channel.ordenarAsync(request);
        }
        
        public System.Threading.Tasks.Task<WSOrden.ordenarResponse> ordenarAsync(WSOrden.shippingOrder orden)
        {
            WSOrden.ordenar inValue = new WSOrden.ordenar();
            inValue.orden = orden;
            return ((WSOrden.orderService)(this)).ordenarAsync(inValue);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.orderServicePort))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.orderServicePort))
            {
                return new System.ServiceModel.EndpointAddress("http://35.193.201.229:8080/orderprocesor/OrderService/orderService");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return orderServiceClient.GetBindingForEndpoint(EndpointConfiguration.orderServicePort);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return orderServiceClient.GetEndpointAddress(EndpointConfiguration.orderServicePort);
        }
        
        public enum EndpointConfiguration
        {
            
            orderServicePort,
        }
    }
}
