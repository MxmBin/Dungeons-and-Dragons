using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace Dungeons_and_Dragons
{
    class ClientClass
    {
        RestClient client;
        RestRequest request;
        IRestResponse response;
        string baseUri = "http://localhost:8080/";

        public ClientClass()
        {
            client = new RestClient();
            client.BaseUrl = new Uri(baseUri);
            request = new RestRequest();
            request.RequestFormat = DataFormat.Json;
        }

        public IRestResponse newGame(string login, string session)
        {
            request = new RestRequest("newGame", Method.POST);
            Request.UserAccount reqBody = new Request.UserAccount();
            reqBody.auth.login = login;
            reqBody.auth.session = session;
            request.AddJsonBody(reqBody);

            response = client.Execute(request);
            return (response);
        }
        //UserAccount usrAcc = new UserAccount();
        //usrAcc.auth.login = UserInfo.UserLogin;
        //    usrAcc.auth.session = UserInfo.UserSession;
        //    request = new RestRequest("newGame", Method.POST);
        //request.AddJsonBody(usrAcc);

        //    IRestResponse response = client.Execute(request);
        //    if (response.IsSuccessful)
        //    {
        //        var serverResponse = JsonConvert.DeserializeObject<ServerResponseNewGame>(response.Content);
        //UserInfo.UserGame = serverResponse.game;
        //        MainMenu mainMenu = new MainMenu();
        //Close();
        //mainMenu.ShowDialog();
        //    }
    }

    class Request
    {
        public class Auth
        {
            public string login { get; set; }
            public string hash { get; set; }
            public string session { get; set; }
            public string token { get; set; }
        }

        public class UserAccount
        {
            public Auth auth;
            public string game { get; set; }
            public int hero { get; set; }

            public UserAccount()
            {
                this.auth = new Auth();
            }
        }

        public class GameConnect
        {
            public string game { get; set; }
            public int hero { get; set; }
        }
    }
}
