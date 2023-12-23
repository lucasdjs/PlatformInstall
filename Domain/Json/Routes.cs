using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformInstall.Domain.Json
{
    public class Routes
    {
        public string DownstreamPathTemplate { get; set; }
        public string DownstreamScheme { get; set; }
        public List<DownstreamHostAndPorts> DownstreamHostAndPorts { get; set; }
        public string UpstreamPathTemplate { get; set; }
        public UpstreamHeaderTransform UpstreamHeaderTransform { get; set; }
    }

    public class DownstreamHostAndPorts
    {
        public string Host { get; set; }
        public int Port { get; set; }
    }

    public class UpstreamHeaderTransform
    {
        [JsonProperty("X-Forwarded-For")]
        public string XForwardedFor { get; set; }
    }
}
