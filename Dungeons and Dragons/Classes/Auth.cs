using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons_and_Dragons.Classes
{
    public class Auth
    {
        public string login { get; set; }
        public string hash { get; set; }
        public string session { get; set; }
        public string token { get; set; }
    }
}
