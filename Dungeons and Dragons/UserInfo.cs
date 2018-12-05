using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons_and_Dragons
{
    // Возможно стоит переделать и сделать обычный класс
    public static class UserInfo
    {
        public static string UserLogin { get; set; }
        public static string UserSession { get; set; }
        public static string UserGame { get; set; }
        public static int UserRole { get; set; }

        public static void DisconnetcUser()
        {
            UserLogin = "";
            UserSession = "";
        }
    }
}
