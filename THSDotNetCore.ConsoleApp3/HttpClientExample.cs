using Microsoft.EntityFrameworkCore.Storage.Json;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
namespace THSDotNetCore.ConsoleApp3;

public class HttpClientExample
{
    private readonly HttpClient _client = new HttpClient();
    private readonly string postEndpoint = "https://jsonplaceholder.typicode.com/posts";

    public bool JsonStr { get; private set; }

    public HttpClientExample()
    {
        _client = new HttpClient();
    }



    public async Task Read()
    {
        var response = await _client.GetAsync(postEndpoint);
        if (response.IsSuccessStatusCode)
        {
            string JsonStr = await response.Content.ReadAsStringAsync();
            Console.WriteLine(JsonStr);
        }
    }


    public async Task Edit(int id)
    {
        var response = await _client.GetAsync($"{postEndpoint} /{id}");

        if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            Console.WriteLine("No data found.");
            return;
        }


        if (response.IsSuccessStatusCode)
        {
            string JsonStr = await response.Content.ReadAsStringAsync();
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

        var jsonRequest = JsonConvert.SerializeObject(requestmodel);
        var content = new StringContent(jsonRequest, Encoding.UTF8, Application.Json);
        var response = await _client.PostAsync(postEndpoint, content);
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine(await response.Content.ReadAsStringAsync());
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

        var jsonRequest = JsonConvert.SerializeObject(requestmodel);
        var content = new StringContent(jsonRequest, Encoding.UTF8, Application.Json);
        var response = await _client.PatchAsync($"{ postEndpoint}/{id}", content);
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine(await response.Content.ReadAsStringAsync());
        }
    }

    public async Task Delete(int id)
    {
        var response = await _client.DeleteAsync($"{postEndpoint} /{id}");

        if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            Console.WriteLine("No data found.");
            return;
        }


        if (response.IsSuccessStatusCode)
        {
            string JsonStr = await response.Content.ReadAsStringAsync();
            Console.WriteLine(JsonStr);
        }
    }
}
    public class PostModel
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
    }



    



    //public HttpClientExample()
    //{
    //    _httpClient = new HttpClient();
    //    _httpClient.BaseAddress = new Uri("https://localhost:7010/api/");
    //}

    //public async Task RunAsync()
    //{
    //    await GetBlogs();
    //    await GetBlog(1);
    //    await CreateBlog();
    //    await UpdateBlog(1);
    //    await DeleteBlog(1);
    //}

    //// GET all
    //public async Task GetBlogs()
    //{
    //    var response = await _httpClient.GetAsync("blog");
    //    var json = await response.Content.ReadAsStringAsync();

    //    Console.WriteLine("GET ALL:");
    //    Console.WriteLine(json);
    //}

    //// GET by id
    //public async Task GetBlog(int id)
    //{
    //    var response = await _httpClient.GetAsync($"blog/{id}");
    //    var json = await response.Content.ReadAsStringAsync();

    //    Console.WriteLine($"GET {id}:");
    //    Console.WriteLine(json);
    //}

    //// POST
    //public async Task CreateBlog()
    //{
    //    var blog = new Blog
    //    {
    //        Title = "New Blog",
    //        Author = "Yurina",
    //        Content = "Created with HttpClient"
    //    };

    //    var json = JsonSerializer.Serialize(blog);
    //    var content = new StringContent(json, Encoding.UTF8, "application/json");

    //    var response = await _httpClient.PostAsync("blog", content);

    //    Console.WriteLine("POST:");
    //    Console.WriteLine(await response.Content.ReadAsStringAsync());
    //}

    //// PUT
    //public async Task UpdateBlog(int id)
    //{
    //    var blog = new Blog
    //    {
    //        Id = id,
    //        Title = "Updated Blog",
    //        Author = "Yurina",
    //        Content = "Updated with HttpClient"
    //    };

    //    var json = JsonSerializer.Serialize(blog);
    //    var content = new StringContent(json, Encoding.UTF8, "application/json");

    //    var response = await _httpClient.PutAsync($"blog/{id}", content);

    //    Console.WriteLine("PUT:");
    //    Console.WriteLine(await response.Content.ReadAsStringAsync());
    //}

    //// DELETE
    //public async Task DeleteBlog(int id)
    //{
    //    var response = await _httpClient.DeleteAsync($"blog/{id}");

    //    Console.WriteLine("DELETE:");
    //    Console.WriteLine(await response.Content.ReadAsStringAsync());
    //}
