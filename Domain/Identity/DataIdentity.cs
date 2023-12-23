using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformInstall.Domain.Identity
{
    public class DataIdentity
    {
        public DataDatabase DataDatabase { get; set; }
        public User UserBackEnd { get; set; }
        public User UserFrontEnd { get; set; }
        public User UserSdk { get; set; }

        public DataIdentity(DataDatabase dataDatabase, User userBackEnd, User userFrontEnd, User userSdk)
        {
            DataDatabase = dataDatabase;
            UserBackEnd = userBackEnd;
            UserFrontEnd = userFrontEnd;
            UserSdk = userSdk;
        }
    }
}
