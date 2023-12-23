using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformInstall.Domain.Identity
{
    public class DataDatabase
    {
        public string idUser { get; set; }
        public string User { get; set; }
        public string Email { get; set; }

        public DataDatabase(string idUser, string user, string email)
        {
            this.idUser = idUser;
            User = user;
            Email = email;
        }
    }
}
