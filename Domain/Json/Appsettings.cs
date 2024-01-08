using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformInstall.Domain.Json
{
    public class Appsettings
    {
        public General General { get; set; }
        public UserProvider UserProvider { get; set; }
    }
}
