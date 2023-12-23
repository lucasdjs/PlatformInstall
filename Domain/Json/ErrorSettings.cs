using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformInstall.Domain.Json
{
    public class ErrorSettings
    {
        public string notFound { get; set; }
        public string unauthorized { get; set; }
        public string forbidden { get; set; }
        public string serverError { get; set; }
        public string unavailable { get; set; }

        public ErrorSettings() { }
    }
}
