using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons_and_Dragons
{
    class ServerResponse
    {
        public class ServerResponseAuth
        {
            public string session { get; set; }
            public int role { get; set; }
        }

        public class ServerResponseNewGame
        {
            public string game { get; set; }
            public string response { get; set; }
        }
    }
}
