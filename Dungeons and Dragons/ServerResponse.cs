using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons_and_Dragons
{
    class ServerResponse
    {
        public string session { get; set; }
        public int role { get; set; }
        public string game { get; set; }
        public HeroClass hero { get; set; }
        public List<Heroes> heroes { get; set; }
    }

    class Heroes
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
