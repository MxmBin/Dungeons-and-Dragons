using System;
using RestSharp;
using Dungeons_and_Dragons.Classes;

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

        public IRestResponse Authorization(string login, string pass)
        {
            request = new RestRequest("auth", Method.POST);
            Request.Auth reqBody = new Request.Auth();
            reqBody.login = login;
            //Получение хеша
            Md5Hash md5 = new Md5Hash();
            reqBody.hash = md5.GetHash(pass);
            request.AddJsonBody(reqBody);

            response = client.Execute(request);
            return (response);
        }

        public IRestResponse Registration(string login, string pass, string token)
        {
            request = new RestRequest("reg", Method.POST);
            Request.Auth reqBody = new Request.Auth();
            reqBody.login = login;
            reqBody.token = token;
            //Получение хеша
            Md5Hash md5 = new Md5Hash();
            reqBody.hash = md5.GetHash(pass);
            request.AddJsonBody(reqBody);

            response = client.Execute(request);
            return (response);
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

        public IRestResponse Connect(User user, int hero)
        {
            request = new RestRequest("connect", Method.POST);
            Request.UserAccount reqBody = new Request.UserAccount();
            reqBody.auth.login = user.Login;
            reqBody.auth.session = user.Session;
            reqBody.game = user.Game;
            reqBody.hero = hero;
            request.AddJsonBody(reqBody);

            response = client.Execute(request);
            return (response);
        }
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

    class User
    {
        public string Login { get; set; }
        public string Session { get; set; }
        public string Game { get; set; }
        public int Role { get; set; }
    }
}
