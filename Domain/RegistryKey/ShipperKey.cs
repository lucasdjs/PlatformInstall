using Microsoft.Win32;
using PlatformInstall.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformInstall.Domain.RegistryKey
{
    public class ShipperKey
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
        public string InstrumentationKey { get; set; }
        public string LogFileName { get; set; }
        public string M2MAuthApiUrl { get; set; }
        public string MiddlewarePersistence { get; set; }
        public string NHibernateDialect { get; set; }
        public string NServiceBusPersistence { get; set; }
        public string PaymentApiUrl { get; set; }
        public string PoliciesApiUrl { get; set; }
        public string SchemasFilePath { get; set; }
        public string SecretKey_Shipper { get; set; }
        public string ShipperCargoOutputPathHistoric { get; set; }
        public string ShipperCargoOutputPathResponse { get; set; }
        public string ShipperCargoOutputPathSend { get; set; }
        public string TenantCode { get; set; }

        public ShipperKey()
        {
        }

        public ShipperKey(User user)
        {
            AuditQueue = "nddigital.audit";
            AuthApiUrl = "https://nddfrete-dev.e-datacenter.nddigital.com.br/";
            CarrierApiUrl = "http://localhost:58702/";
            ClientId_Shipper = user.ClientId;
            ConnectionStringAuth = "Data Source=localhost;Initial Catalog=Shipper;Persist Security Info=True;User ID=sa;Password=321;Connect Timeout=120";
            ConnectionStringDocumentStorage = "Data Source=localhost;Initial Catalog=DocumentStorage;Persist Security Info=True;User ID=sa;Password=senha;Connect Timeout=120";
            ConnectionStringMonitoring = "Data Source=localhost;Initial Catalog=Monitoring;Persist Security Info=True;User ID=sa;Password=321;Connect Timeout=120";
            ConnectionStringPayment = "Data Source=localhost;Initial Catalog=Payment;Persist Security Info=True;User ID=sa;Password=321;Connect Timeout=120";
            ConnectionStringShipper = "Data Source=localhost;Initial Catalog=Shipper;Persist Security Info=True;User ID=sa;Password=321;Connect Timeout=120";
            ConnectionStringTaxCalculation = "Data Source=localhost;Initial Catalog=Shipper;Persist Security Info=True;User ID=sa;Password=321;Connect Timeout=120";
            CreateQueues = "1";
            CriticalErrorTimeout = "60";
            ErrorQueue = "nddigital.error";
            FileSharePath = "C:\\NDDTemp\\Third Part Logistic\\NServiceBus";
            InstrumentationKey = "InstrumentationKey";
            LogFileName = "C:\\git.nddigital\\nddFrete_Shipper\\Configurations\\FileLog\\Shipper\\defaultlogfile.xml";
            M2MAuthApiUrl = "https://nddfrete-dev.e-datacenter.nddigital.com.br/";
            MiddlewarePersistence = "Data Source=localhost;Initial Catalog=Shipper;Persist Security Info=True;User ID=sa;Password=321;Connect Timeout=120";
            NHibernateDialect = "NHibernate.Dialect.MsSql2012Dialect";
            NServiceBusPersistence = "Data Source=localhost;Initial Catalog=Shipper;Persist Security Info=True;User ID=sa;Password=321;Connect Timeout=120";
            PaymentApiUrl = "http://localhost:56330/";
            PoliciesApiUrl = "https://nddfrete-pol-dev.e-datacenter.nddigital.com.br/";
            SchemasFilePath = "C:\\git.nddigital\\nddFrete_Shipper\\Configurations\\Schemas";
            SecretKey_Shipper = user.SecretKey;
            ShipperCargoOutputPathHistoric = "C:\\nddCargo\\Agente\\historic";
            ShipperCargoOutputPathResponse = "C:\\nddCargo\\Agente\\retornos";
            ShipperCargoOutputPathSend = "C:\\nddCargo\\Agente\\envios";
            TenantCode = "ndd";
        }
    }
}
