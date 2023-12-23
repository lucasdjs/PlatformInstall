using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformInstall.Domain.Json
{
    public class App
    {
        public string name { get; set; }
        public string specfile { get; set; }
        public string basePath { get; set; }
        public string client_id { get; set; }
        public List<string> exclude { get; set; }
        public string standalone { get; set; }

        public App()
        {
        }
    }
}
