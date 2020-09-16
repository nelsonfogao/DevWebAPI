using Domain;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Request
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Email:");
            var email = Console.ReadLine();
            Console.WriteLine("Senha:");
            var senha = Console.ReadLine();

            var client = new RestClient();

            var requestToken = new RestRequest("https://localhost:5001/api/authenticate/token");
            requestToken.AddJsonBody(JsonConvert.SerializeObject(new { Email = email, Senha = senha }));

            var token = client.Post<TokenResult>(requestToken).Data;

            var request = new RestRequest("https://localhost:5001/api/amigo", DataFormat.Json);
            request.AddHeader("Authorization", "Bearer" + token.Token);
            var response = client.Get<List<Amigo>>(request);
            Console.WriteLine((response.Data));
            Console.ReadKey();

         
        }
        public class TokenResult
        {
            public String Token { get; set; }
        }
    }
}
