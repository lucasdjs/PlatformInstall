using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformInstall.Domain.Json
{
    public class NddGateway
    {
        public List<Routes> Routes { get; set; }
        public GlobalConfiguration GlobalConfiguration { get; set; }
    }
}
