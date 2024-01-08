using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformInstall.Domain.Json
{
    public class General
    {
        [JsonProperty("ConnectionStringCache")]
        public string ConnectionStringCache { get; set; }
        [JsonProperty("StorageUrl")]
        public string StorageUrl { get; set; }
    }
}
