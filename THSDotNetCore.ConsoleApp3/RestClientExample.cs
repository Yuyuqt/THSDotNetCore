using RestSharp;
using System;
using System.Reflection.Metadata;
using System.Threading.Tasks;

public class RestClientExample
{
    private readonly RestClient _client;

    public RestClientExample()
    {
        _client = new RestClient("https://localhost:7010/api/");
    }

    public async Task RunAsync()
    {
        await GetBlogs();
        await GetBlog(1);
        await CreateBlog();
        await UpdateBlog(1);
        await DeleteBlog(1);
    }

    // GET all
    public async Task GetBlogs()
    {
        var request = new RestRequest("blog", Method.Get);
        var response = await _client.ExecuteAsync(request);

        Console.WriteLine("GET ALL:");
        Console.WriteLine(response.Content);
    }

    // GET by id
    public async Task GetBlog(int id)
    {
        var request = new RestRequest($"blog/{id}", Method.Get);
        var response = await _client.ExecuteAsync(request);

        Console.WriteLine($"GET {id}:");
        Console.WriteLine(response.Content);
    }

    // POST
    public async Task CreateBlog()
    {
        var blog = new Blog
        {
            Title = "New Blog",
            Author = "Yurina",
            Content = "Created with RestClient"
        };

        var request = new RestRequest("blog", Method.Post);
        request.AddJsonBody(blog);

        var response = await _client.ExecuteAsync(request);

        Console.WriteLine("POST:");
        Console.WriteLine(response.Content);
    }

    // PUT
    public async Task UpdateBlog(int id)
    {
        var blog = new Blog
        {
            Id = id,
            Title = "Updated Blog",
            Author = "Yurina",
            Content = "Updated with RestClient"
        };

        var request = new RestRequest($"blog/{id}", Method.Put);
        request.AddJsonBody(blog);

        var response = await _client.ExecuteAsync(request);

        Console.WriteLine("PUT:");
        Console.WriteLine(response.Content);
    }

    // DELETE
    public async Task DeleteBlog(int id)
    {
        var request = new RestRequest($"blog/{id}", Method.Delete);
        var response = await _client.ExecuteAsync(request);

        Console.WriteLine("DELETE:");
        Console.WriteLine(response.Content);
    }
}