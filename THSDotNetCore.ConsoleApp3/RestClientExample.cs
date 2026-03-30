using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace THSDotNetCore.ConsoleApp3
{
    public class RestClientExample
    {

        private readonly RestClient _client = new RestClient();
        private readonly string postEndpoint = "https://jsonplaceholder.typicode.com/posts";

        public bool JsonStr { get; private set; }

        public RestClientExample()
        {
            _client = new RestClient();
        }



        public async Task Read()
        {
            RestRequest request = new RestRequest("posts", Method.Get);
            var response = await _client.GetAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string JsonStr =  response.Content!;
                Console.WriteLine(JsonStr);
            }
        }


        public async Task Edit(int id)
        {
            RestRequest request = new RestRequest($"{postEndpoint} /{id}", Method.Get);
            var response = await _client.ExecuteAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                Console.WriteLine("No data found.");
                return;
            }


            if (response.IsSuccessStatusCode)
            {
                string JsonStr =  response.Content!;
                Console.WriteLine(JsonStr);
            }
        }
        public async Task Create(String title, string body, int userId)
        {
            PostModel requestmodel = new PostModel()
            {
                body = body,
                title = title,
                userId = userId
            };// C# object | .NET object
            RestRequest request = new RestRequest(postEndpoint, Method.Post);
            request.AddJsonBody(requestmodel);

            //var jsonRequest = JsonConvert.SerializeObject(requestmodel);
            //var content = new StringContent(jsonRequest, Encoding.UTF8, Application.Json);

            var response = await _client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine( response.Content!);
            }
        }

        public async Task Update(int id, String title, string body, int userId)
        {
            PostModel requestmodel = new PostModel()
            {

                body = body,
                title = title,
                userId = userId
            };// C# object | .NET object
            RestRequest request = new RestRequest(postEndpoint, Method.Patch);
            request.AddJsonBody(requestmodel);

            //var jsonRequest = JsonConvert.SerializeObject(requestmodel);
            //var content = new StringContent(jsonRequest, Encoding.UTF8, Application.Json);

            var response = await _client.ExecuteAsync(request);

            

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine( response.Content!);
            }
        }

        public async Task Delete(int id)
        {
            RestRequest request = new RestRequest($"{postEndpoint} /{id}", Method.Delete);
            var response = await _client.ExecuteAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                Console.WriteLine("No data found.");
                return;
            }


            if (response.IsSuccessStatusCode)
            {
                string JsonStr =  response.Content;
                Console.WriteLine(JsonStr);
            }
        }
    }
}
