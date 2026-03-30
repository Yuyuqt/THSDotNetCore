// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

HttpClient client = new HttpClient();
var response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts");
if (response.IsSuccessStatusCode)
{
    string JsonStr = await response.Content.ReadAsStringAsync();
    Console.WriteLine(JsonStr);
}


//await new HttpClientExample().RunAsync();
// OR
//await new RestClientExample().RunAsync();