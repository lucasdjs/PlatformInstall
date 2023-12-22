using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PlaformInstall.Services.ScriptCommandService;

namespace PlatformInstall.Domain.Json
{
    class Configuracao
    {
        public string defaultApp { get; set; }
        public string authPath { get; set; }
        public List<App> apps { get; set; }
        public ErrorSettings errorSettings { get; set; }

        public Configuracao() { }
    }
}
