using RestSharp;
using System;
using System.Collections.Generic;

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

        public IRestResponse delGame(string login, string session)
        {
            request = new RestRequest("newGame", Method.DELETE);
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

        public IRestResponse DelConnect(string login, string session)
        {
            request = new RestRequest("connect", Method.DELETE);
            Request.UserAccount reqBody = new Request.UserAccount();
            reqBody.auth.login = login;
            reqBody.auth.session = session;
            request.AddJsonBody(reqBody);

            response = client.Execute(request);
            return (response);
        }

        public IRestResponse heroList(string login, string session)
        {
            request = new RestRequest("heroList", Method.GET);
            request.AddParameter("login", login);
            request.AddParameter("session", session);

            response = client.Execute(request);
            return (response);
        }

        public IRestResponse Hero(string login, string session, string game)
        {
            request = new RestRequest(game + "/Hero", Method.GET);
            request.AddParameter("login", login);
            request.AddParameter("session", session);

            response = client.Execute(request);
            return (response);
        }

        public IRestResponse saveHero(string game, string login, string session, ReqHero hero)
        {
            request = new RestRequest(game + "/SaveHero?login="+login+"&session="+session, Method.PATCH);
            request.AddJsonBody(hero);

            IRestResponse response = client.Execute(request);
            return (response);
        }

        public IRestResponse Games(string login, string session)
        {
            request = new RestRequest("games", Method.GET);
            request.AddParameter("login", login);
            request.AddParameter("session", session);

            response = client.Execute(request);
            return (response);
        }

        public IRestResponse Loot(string login, string session, string game, RootObject loot)
        {
            request = new RestRequest(game + "/Loot?login=" + login + "&session=" + session, Method.POST);
            request.AddJsonBody(loot);

            response = client.Execute(request);
            return (response);
        }

        public IRestResponse DelLoot(string login, string session, string game)
        {
            request = new RestRequest(game + "/Loot?login=" + login + "&session=" + session, Method.DELETE);

            response = client.Execute(request);
            return (response);
        }

        public IRestResponse OthersPlayers(string login, string session, string game)
        {
            request = new RestRequest(game + "/Other", Method.GET);
            request.AddParameter("login", login);
            request.AddParameter("session", session);

            response = client.Execute(request);
            return (response);
        }

        public IRestResponse newHero(string login, string session, ReqHero hero)
        {
            request = new RestRequest("newHero?login=" + login + "&session=" + session, Method.POST);
            request.AddJsonBody(hero);

            response = client.Execute(request);
            return (response);
        }

        public IRestResponse Manual()
        {
            request = new RestRequest("manual", Method.GET);

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
                auth = new Auth();
            }
        }

        public class GameConnect
        {
            public string game { get; set; }
            public int hero { get; set; }
        }
    }

    

    class RootObject
    {
        public Loot loot { get; set; }

        public RootObject()
        {
            loot = new Loot();
        }

        public class Loot
        {
            public List<Weapon> weapons { get; set; }
            public List<Item> items { get; set; }
            public List<Armor> armors { get; set; }

            public Loot()
            {
                weapons = new List<Weapon>();
                items = new List<Item>();
                armors = new List<Armor>();
            }
        }

        public class Weapon
        {
            public int id { get; set; }
            public int count { get; set; }
        }

        public class Item
        {
            public int id { get; set; }
            public int count { get; set; }
        }

        public class Armor
        {
            public int id { get; set; }
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
