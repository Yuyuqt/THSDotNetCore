// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;

Console.WriteLine("Hello, World!");


var blog = new BlogModel
{
    Id = 1,
    Title = "Test title",
    Author = "Test author",
    Content = "Test content",

};

//string jsonStr = JsonConvert.SerializeObject(blog, Formatting.Indented);
string jsonStr = blog.ToJson(); //#C to JSON

Console.WriteLine(jsonStr);

string jsonStr2 = """{ "Id": 1, "Title": "Test title","Author": "Test author","Content": "Test content", "DeleteFlag": false}""";
 var blog2 = JsonConvert.DeserializeObject<BlogModel>(jsonStr2);    

//System.Text.Json.JsonSerializer.Serialize(blog);
//System.Text.Json.JsonSerializer.Deserialize<BlogModel>(jsonStr2);
  
Console.WriteLine(blog2.Title);  
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

