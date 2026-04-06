using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

using var loggerFactory = LoggerFactory.Create(builder =>
{
    builder.AddConsole();
});

ILogger logger = loggerFactory.CreateLogger<Program>();

logger.LogInformation("Hello, World!");


var blog = new BlogModel
{
    Id = 1,
    Title = "Test title",
    Author = "Test author",
    Content = "Test content",

};

string jsonStr = blog.ToJson(); //#C to JSON

logger.LogInformation("Serialized Blog: {Json}", jsonStr);

string jsonStr2 = """{ "Id": 1, "Title": "Test title","Author": "Test author","Content": "Test content", "DeleteFlag": false}""";
var blog2 = JsonConvert.DeserializeObject<BlogModel>(jsonStr2);    

logger.LogInformation("Deserialized Blog Title: {Title}", blog2?.Title);  
Console.ReadLine();

public class BlogModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Content { get; set; }
    public bool DeleteFlag { get; set; }
}

public static class Extensions //DevCode
{ 
    public static string ToJson(this object obj)
    {
        string jsonStr = JsonConvert.SerializeObject(obj, Formatting.Indented);
        return jsonStr;
    }
}

