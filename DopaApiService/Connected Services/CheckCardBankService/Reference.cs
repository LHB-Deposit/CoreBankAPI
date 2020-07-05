﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CheckCardBankService
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ResponseOut", Namespace="http://tempuri.org/")]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(CheckCardBankService.CardStatusOut))]
    public partial class ResponseOut : object
    {
        
        private bool IsErrorField;
        
        private string ErrorMessageField;
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public bool IsError
        {
            get
            {
                return this.IsErrorField;
            }
            set
            {
                this.IsErrorField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string ErrorMessage
        {
            get
            {
                return this.ErrorMessageField;
            }
            set
            {
                this.ErrorMessageField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CardStatusOut", Namespace="http://tempuri.org/")]
    public partial class CardStatusOut : CheckCardBankService.ResponseOut
    {
        
        private ushort CodeField;
        
        private string DescField;
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public ushort Code
        {
            get
            {
                return this.CodeField;
            }
            set
            {
                this.CodeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string Desc
        {
            get
            {
                return this.DescField;
            }
            set
            {
                this.DescField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CheckCardBankService.CheckCardBankServiceSoap")]
    public interface CheckCardBankServiceSoap
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/CheckCardByLaser", ReplyAction="*")]
        System.Threading.Tasks.Task<CheckCardBankService.CheckCardByLaserResponse> CheckCardByLaserAsync(CheckCardBankService.CheckCardByLaserRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/CheckCardByCID", ReplyAction="*")]
        System.Threading.Tasks.Task<CheckCardBankService.CheckCardByCIDResponse> CheckCardByCIDAsync(CheckCardBankService.CheckCardByCIDRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class CheckCardByLaserRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="CheckCardByLaser", Namespace="http://tempuri.org/", Order=0)]
        public CheckCardBankService.CheckCardByLaserRequestBody Body;
        
        public CheckCardByLaserRequest()
        {
        }
        
        public CheckCardByLaserRequest(CheckCardBankService.CheckCardByLaserRequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class CheckCardByLaserRequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string PID;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string FirstName;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string LastName;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string BirthDay;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string Laser;
        
        public CheckCardByLaserRequestBody()
        {
        }
        
        public CheckCardByLaserRequestBody(string PID, string FirstName, string LastName, string BirthDay, string Laser)
        {
            this.PID = PID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.BirthDay = BirthDay;
            this.Laser = Laser;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class CheckCardByLaserResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="CheckCardByLaserResponse", Namespace="http://tempuri.org/", Order=0)]
        public CheckCardBankService.CheckCardByLaserResponseBody Body;
        
        public CheckCardByLaserResponse()
        {
        }
        
        public CheckCardByLaserResponse(CheckCardBankService.CheckCardByLaserResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class CheckCardByLaserResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public CheckCardBankService.CardStatusOut CheckCardByLaserResult;
        
        public CheckCardByLaserResponseBody()
        {
        }
        
        public CheckCardByLaserResponseBody(CheckCardBankService.CardStatusOut CheckCardByLaserResult)
        {
            this.CheckCardByLaserResult = CheckCardByLaserResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class CheckCardByCIDRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="CheckCardByCID", Namespace="http://tempuri.org/", Order=0)]
        public CheckCardBankService.CheckCardByCIDRequestBody Body;
        
        public CheckCardByCIDRequest()
        {
        }
        
        public CheckCardByCIDRequest(CheckCardBankService.CheckCardByCIDRequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class CheckCardByCIDRequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string ChipNo;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string pid;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string bp1no;
        
        public CheckCardByCIDRequestBody()
        {
        }
        
        public CheckCardByCIDRequestBody(string ChipNo, string pid, string bp1no)
        {
            this.ChipNo = ChipNo;
            this.pid = pid;
            this.bp1no = bp1no;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class CheckCardByCIDResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="CheckCardByCIDResponse", Namespace="http://tempuri.org/", Order=0)]
        public CheckCardBankService.CheckCardByCIDResponseBody Body;
        
        public CheckCardByCIDResponse()
        {
        }
        
        public CheckCardByCIDResponse(CheckCardBankService.CheckCardByCIDResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class CheckCardByCIDResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public CheckCardBankService.CardStatusOut CheckCardByCIDResult;
        
        public CheckCardByCIDResponseBody()
        {
        }
        
        public CheckCardByCIDResponseBody(CheckCardBankService.CardStatusOut CheckCardByCIDResult)
        {
            this.CheckCardByCIDResult = CheckCardByCIDResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public interface CheckCardBankServiceSoapChannel : CheckCardBankService.CheckCardBankServiceSoap, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public partial class CheckCardBankServiceSoapClient : System.ServiceModel.ClientBase<CheckCardBankService.CheckCardBankServiceSoap>, CheckCardBankService.CheckCardBankServiceSoap
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public CheckCardBankServiceSoapClient(EndpointConfiguration endpointConfiguration) : 
                base(CheckCardBankServiceSoapClient.GetBindingForEndpoint(endpointConfiguration), CheckCardBankServiceSoapClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public CheckCardBankServiceSoapClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(CheckCardBankServiceSoapClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public CheckCardBankServiceSoapClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(CheckCardBankServiceSoapClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public CheckCardBankServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<CheckCardBankService.CheckCardByLaserResponse> CheckCardBankService.CheckCardBankServiceSoap.CheckCardByLaserAsync(CheckCardBankService.CheckCardByLaserRequest request)
        {
            return base.Channel.CheckCardByLaserAsync(request);
        }
        
        public System.Threading.Tasks.Task<CheckCardBankService.CheckCardByLaserResponse> CheckCardByLaserAsync(string PID, string FirstName, string LastName, string BirthDay, string Laser)
        {
            CheckCardBankService.CheckCardByLaserRequest inValue = new CheckCardBankService.CheckCardByLaserRequest();
            inValue.Body = new CheckCardBankService.CheckCardByLaserRequestBody();
            inValue.Body.PID = PID;
            inValue.Body.FirstName = FirstName;
            inValue.Body.LastName = LastName;
            inValue.Body.BirthDay = BirthDay;
            inValue.Body.Laser = Laser;
            return ((CheckCardBankService.CheckCardBankServiceSoap)(this)).CheckCardByLaserAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<CheckCardBankService.CheckCardByCIDResponse> CheckCardBankService.CheckCardBankServiceSoap.CheckCardByCIDAsync(CheckCardBankService.CheckCardByCIDRequest request)
        {
            return base.Channel.CheckCardByCIDAsync(request);
        }
        
        public System.Threading.Tasks.Task<CheckCardBankService.CheckCardByCIDResponse> CheckCardByCIDAsync(string ChipNo, string pid, string bp1no)
        {
            CheckCardBankService.CheckCardByCIDRequest inValue = new CheckCardBankService.CheckCardByCIDRequest();
            inValue.Body = new CheckCardBankService.CheckCardByCIDRequestBody();
            inValue.Body.ChipNo = ChipNo;
            inValue.Body.pid = pid;
            inValue.Body.bp1no = bp1no;
            return ((CheckCardBankService.CheckCardBankServiceSoap)(this)).CheckCardByCIDAsync(inValue);
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
            if ((endpointConfiguration == EndpointConfiguration.CheckCardBankServiceSoap))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                result.Security.Mode = System.ServiceModel.BasicHttpSecurityMode.Transport;
                return result;
            }
            if ((endpointConfiguration == EndpointConfiguration.CheckCardBankServiceSoap12))
            {
                System.ServiceModel.Channels.CustomBinding result = new System.ServiceModel.Channels.CustomBinding();
                System.ServiceModel.Channels.TextMessageEncodingBindingElement textBindingElement = new System.ServiceModel.Channels.TextMessageEncodingBindingElement();
                textBindingElement.MessageVersion = System.ServiceModel.Channels.MessageVersion.CreateVersion(System.ServiceModel.EnvelopeVersion.Soap12, System.ServiceModel.Channels.AddressingVersion.None);
                result.Elements.Add(textBindingElement);
                System.ServiceModel.Channels.HttpsTransportBindingElement httpsBindingElement = new System.ServiceModel.Channels.HttpsTransportBindingElement();
                httpsBindingElement.AllowCookies = true;
                httpsBindingElement.MaxBufferSize = int.MaxValue;
                httpsBindingElement.MaxReceivedMessageSize = int.MaxValue;
                result.Elements.Add(httpsBindingElement);
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.CheckCardBankServiceSoap))
            {
                return new System.ServiceModel.EndpointAddress("https://idcard.bora.dopa.go.th/CheckCardStatus/CheckCardService.asmx");
            }
            if ((endpointConfiguration == EndpointConfiguration.CheckCardBankServiceSoap12))
            {
                return new System.ServiceModel.EndpointAddress("https://idcard.bora.dopa.go.th/CheckCardStatus/CheckCardService.asmx");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        public enum EndpointConfiguration
        {
            
            CheckCardBankServiceSoap,
            
            CheckCardBankServiceSoap12,
        }
    }
}
