using PlatformInstall.Domain.Identity;

namespace PlatformInstall.Domain.RegistryKey
{
    public class ShipperKeyTest
    {
        public string AuditQueue { get; set; }
        public string AuthApiUrl { get; set; }
        public string CarrierApiUrl { get; set; }
        public string ClientId_Shipper { get; set; }
        public string ConnectionStringAuth { get; set; }
        public string ConnectionStringDocumentStorage { get; set; }
        public string ConnectionStringMonitoring { get; set; }
        public string ConnectionStringPayment { get; set; }
        public string ConnectionStringShipper { get; set; }
        public string ConnectionStringTaxCalculation { get; set; }
        public string CreateQueues { get; set; }
        public string CriticalErrorTimeout { get; set; }
        public string ErrorQueue { get; set; }
        public string FileSharePath { get; set; }
        public string LogFileName { get; set; }
        public string MiddlewarePersistence { get; set; }
        public string NHibernateDialect { get; set; }
        public string NServiceBusPersistence { get; set; }
        public string PaymentApiUrl { get; set; }
        public string SchemasFilePath { get; set; }
        public string SecretKey_Shipper { get; set; }
        public string ShipperCargoOutputPathHistoric { get; set; }
        public string ShipperCargoOutputPathResponse { get; set; }
        public string ShipperCargoOutputPathSend { get; set; }
        public string CarrierServicePassword { get; set; }
        public string CarrierServiceUsername { get; set; }
        public string PaymentServicePassword { get; set; }
        public string PaymentServiceUsername { get; set; }

        public ShipperKeyTest()
        {
        }

        public ShipperKeyTest(User user)
        {
            AuditQueue = "nddigital.audit";
            AuthApiUrl = "https://nddfrete-dev.e-datacenter.nddigital.com.br/";
            CarrierApiUrl = "http://localhost:58702/";
            CarrierServicePassword = "123456";
            CarrierServiceUsername = "user_service";
            ClientId_Shipper = user.ClientId;
            ConnectionStringAuth = "Data Source=localhost;Initial Catalog=Shipper_Test;Persist Security Info=True;User ID=sa;Password=321;Connect Timeout=120";
            ConnectionStringDocumentStorage = "Data Source=localhost;Initial Catalog=DocumentStorage_Test;Persist Security Info=True;User ID=sa;Password=senha;Connect Timeout=120";
            ConnectionStringMonitoring = "Data Source=localhost;Initial Catalog=Monitoring_Test;Persist Security Info=True;User ID=sa;Password=321;Connect Timeout=120";
            ConnectionStringPayment = "Data Source=localhost;Initial Catalog=Payment_Test;Persist Security Info=True;User ID=sa;Password=321;Connect Timeout=120";
            ConnectionStringShipper = "Data Source=localhost;Initial Catalog=Shipper_Test;Persist Security Info=True;User ID=sa;Password=321;Connect Timeout=120";
            ConnectionStringTaxCalculation = "Data Source=localhost;Initial Catalog=Shipper_Test;Persist Security Info=True;User ID=sa;Password=321;Connect Timeout=120";
            CreateQueues = "1";
            CriticalErrorTimeout = "60";
            ErrorQueue = "nddigital.error";
            FileSharePath = "C:\\NDDTemp\\Third Part Logistic\\NServiceBus";
            LogFileName = "C:\\git.nddigital\\nddFrete_Shipper\\Configurations\\FileLog\\Shipper\\defaultlogfile.xml";
            MiddlewarePersistence = "Data Source=localhost;Initial Catalog=Shipper_Test;Persist Security Info=True;User ID=sa;Password=321;Connect Timeout=120";
            NHibernateDialect = "NHibernate.Dialect.MsSql2012Dialect";
            NServiceBusPersistence = "Data Source=localhost;Initial Catalog=Shipper_Test;Persist Security Info=True;User ID=sa;Password=321;Connect Timeout=120";
            PaymentApiUrl = "http://localhost:56330/";
            PaymentServicePassword = "123456";
            PaymentServiceUsername = "user_service";
            SchemasFilePath = "C:\\git.nddigital\\nddFrete_Shipper\\Configurations\\Schemas";
            SecretKey_Shipper = user.SecretKey;
            ShipperCargoOutputPathHistoric = "C:\\nddCargo\\Agente\\historic";
            ShipperCargoOutputPathResponse = "C:\\nddCargo\\Agente\\retornos";
            ShipperCargoOutputPathSend = "C:\\nddCargo\\Agente\\envios";
        }
    }
}
