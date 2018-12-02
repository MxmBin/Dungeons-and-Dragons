using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons_and_Dragons.Classes
{
    class UserAccount
    {

        public Auth auth;
        public string game { get; set; }
        public int hero { get; set; }

        public UserAccount()
        {
            this.auth = new Auth();
        }

    }
}
