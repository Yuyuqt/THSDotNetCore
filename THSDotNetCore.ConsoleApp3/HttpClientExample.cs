using System;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public class HttpClientExample
{
    private readonly HttpClient _httpClient;

    public HttpClientExample()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("https://localhost:7010/api/");
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
        var response = await _httpClient.GetAsync("blog");
        var json = await response.Content.ReadAsStringAsync();

        Console.WriteLine("GET ALL:");
        Console.WriteLine(json);
    }

    // GET by id
    public async Task GetBlog(int id)
    {
        var response = await _httpClient.GetAsync($"blog/{id}");
        var json = await response.Content.ReadAsStringAsync();

        Console.WriteLine($"GET {id}:");
        Console.WriteLine(json);
    }

    // POST
    public async Task CreateBlog()
    {
        var blog = new Blog
        {
            Title = "New Blog",
            Author = "Yurina",
            Content = "Created with HttpClient"
        };

        var json = JsonSerializer.Serialize(blog);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("blog", content);

        Console.WriteLine("POST:");
        Console.WriteLine(await response.Content.ReadAsStringAsync());
    }

    // PUT
    public async Task UpdateBlog(int id)
    {
        var blog = new Blog
        {
            Id = id,
            Title = "Updated Blog",
            Author = "Yurina",
            Content = "Updated with HttpClient"
        };

        var json = JsonSerializer.Serialize(blog);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PutAsync($"blog/{id}", content);

        Console.WriteLine("PUT:");
        Console.WriteLine(await response.Content.ReadAsStringAsync());
    }

    // DELETE
    public async Task DeleteBlog(int id)
    {
        var response = await _httpClient.DeleteAsync($"blog/{id}");

        Console.WriteLine("DELETE:");
        Console.WriteLine(await response.Content.ReadAsStringAsync());
    }
}