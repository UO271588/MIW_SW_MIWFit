﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WSClient.DataWS
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="User", Namespace="http://schemas.datacontract.org/2004/07/WS.MIWFit.Data.Model")]
    public partial class User : object
    {
        
        private WSClient.DataWS.FitStats[] FitStatsField;
        
        private string GenreField;
        
        private int IdField;
        
        private string MailField;
        
        private string PasswordField;
        
        private string UsernameField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public WSClient.DataWS.FitStats[] FitStats
        {
            get
            {
                return this.FitStatsField;
            }
            set
            {
                this.FitStatsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Genre
        {
            get
            {
                return this.GenreField;
            }
            set
            {
                this.GenreField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Mail
        {
            get
            {
                return this.MailField;
            }
            set
            {
                this.MailField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password
        {
            get
            {
                return this.PasswordField;
            }
            set
            {
                this.PasswordField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Username
        {
            get
            {
                return this.UsernameField;
            }
            set
            {
                this.UsernameField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="FitStats", Namespace="http://schemas.datacontract.org/2004/07/WS.MIWFit.Data.Model")]
    public partial class FitStats : object
    {
        
        private string ActivityField;
        
        private double CaloriesField;
        
        private System.DateTime DateField;
        
        private double DeficitField;
        
        private double HeightField;
        
        private int IdField;
        
        private double ImcField;
        
        private double SuperavitField;
        
        private WSClient.DataWS.User UserField;
        
        private double WeightField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Activity
        {
            get
            {
                return this.ActivityField;
            }
            set
            {
                this.ActivityField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Calories
        {
            get
            {
                return this.CaloriesField;
            }
            set
            {
                this.CaloriesField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Date
        {
            get
            {
                return this.DateField;
            }
            set
            {
                this.DateField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Deficit
        {
            get
            {
                return this.DeficitField;
            }
            set
            {
                this.DeficitField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Height
        {
            get
            {
                return this.HeightField;
            }
            set
            {
                this.HeightField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Imc
        {
            get
            {
                return this.ImcField;
            }
            set
            {
                this.ImcField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Superavit
        {
            get
            {
                return this.SuperavitField;
            }
            set
            {
                this.SuperavitField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public WSClient.DataWS.User User
        {
            get
            {
                return this.UserField;
            }
            set
            {
                this.UserField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Weight
        {
            get
            {
                return this.WeightField;
            }
            set
            {
                this.WeightField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://ws.miwfit/data/", ConfigurationName="WSClient.DataWS.IDataServices")]
    public interface IDataServices
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ws.miwfit/data/IDataServices/GetUser", ReplyAction="http://ws.miwfit/data/IDataServices/GetUserResponse")]
        System.Threading.Tasks.Task<WSClient.DataWS.User> GetUserAsync(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ws.miwfit/data/IDataServices/CreateUser", ReplyAction="http://ws.miwfit/data/IDataServices/CreateUserResponse")]
        System.Threading.Tasks.Task CreateUserAsync(string username, string password, string genre, string mail);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ws.miwfit/data/IDataServices/GetUserFitStats", ReplyAction="http://ws.miwfit/data/IDataServices/GetUserFitStatsResponse")]
        System.Threading.Tasks.Task<WSClient.DataWS.FitStats[]> GetUserFitStatsAsync(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ws.miwfit/data/IDataServices/CreateUserFitStats", ReplyAction="http://ws.miwfit/data/IDataServices/CreateUserFitStatsResponse")]
        System.Threading.Tasks.Task CreateUserFitStatsAsync(WSClient.DataWS.FitStats fitStats);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    public interface IDataServicesChannel : WSClient.DataWS.IDataServices, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    public partial class DataServicesClient : System.ServiceModel.ClientBase<WSClient.DataWS.IDataServices>, WSClient.DataWS.IDataServices
    {
        
        /// <summary>
        /// Implemente este método parcial para configurar el punto de conexión de servicio.
        /// </summary>
        /// <param name="serviceEndpoint">El punto de conexión para configurar</param>
        /// <param name="clientCredentials">Credenciales de cliente</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public DataServicesClient() : 
                base(DataServicesClient.GetDefaultBinding(), DataServicesClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IDataServices.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public DataServicesClient(EndpointConfiguration endpointConfiguration) : 
                base(DataServicesClient.GetBindingForEndpoint(endpointConfiguration), DataServicesClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public DataServicesClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(DataServicesClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public DataServicesClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(DataServicesClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public DataServicesClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<WSClient.DataWS.User> GetUserAsync(string username)
        {
            return base.Channel.GetUserAsync(username);
        }
        
        public System.Threading.Tasks.Task CreateUserAsync(string username, string password, string genre, string mail)
        {
            return base.Channel.CreateUserAsync(username, password, genre, mail);
        }
        
        public System.Threading.Tasks.Task<WSClient.DataWS.FitStats[]> GetUserFitStatsAsync(string username)
        {
            return base.Channel.GetUserFitStatsAsync(username);
        }
        
        public System.Threading.Tasks.Task CreateUserFitStatsAsync(WSClient.DataWS.FitStats fitStats)
        {
            return base.Channel.CreateUserFitStatsAsync(fitStats);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IDataServices))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("No se pudo encontrar un punto de conexión con el nombre \"{0}\".", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IDataServices))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:9090/DataServices.svc");
            }
            throw new System.InvalidOperationException(string.Format("No se pudo encontrar un punto de conexión con el nombre \"{0}\".", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return DataServicesClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IDataServices);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return DataServicesClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IDataServices);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_IDataServices,
        }
    }
}
