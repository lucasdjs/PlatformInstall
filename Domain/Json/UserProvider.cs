using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformInstall.Domain.Json
{
    public class UserProvider
    {
        public string Name { get; set; }
        public string IntegrationURL { get; set; }
        public string Tenant { get; set; }
        public string ClientID { get; set; }
        public string ClientSecret { get; set; }
    }
}
