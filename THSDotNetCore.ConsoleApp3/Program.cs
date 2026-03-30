// See https://aka.ms/new-console-template for more information
using THSDotNetCore.ConsoleApp3;
Console.WriteLine("Hello, World!");

// HttpClientExample HttpClientExample = new HttpClientExample();
//await HttpClientExample.Read();
//await HttpClientExample.Edit(1);
//await HttpClientExample.Edit(101);

// await HttpClientExample.Create("test title", "test body", 1);
// await HttpClientExample.Update(1, "test title", "test body", 1);

RefitExample refitExample = new RefitExample(); 
await refitExample.Run();
