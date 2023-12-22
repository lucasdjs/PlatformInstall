using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformInstall.Domain.Identity
{
    public class User
    {
        public string ClientId { get; set; }
        public string SecretKey { get; set; }

        public User(string clientId, string secretKey)
        {
            ClientId = clientId;
            SecretKey = secretKey;
        }
    }
}
