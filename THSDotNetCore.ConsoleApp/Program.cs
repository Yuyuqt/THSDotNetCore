using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using THSDotNetCore.ConsoleApp;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            //AdoDotNetExample adoDotNetExample = new AdoDotNetExampleO;
            //adoDotNetExample.Read();

            //adoDotNetExample.Create();
            //adoDotNetExample.Edit();
            //adoDotNetExample.Update();
            //adoDotNetExample.Delete();

            //DapperExample dapperExample = new DapperExample();
            //dapperExample.Read();

            //dapperExample.Create("dafadfs"，"dasdfasssf"，"dfasf");
            //dapperExample.Edit(1);

            //EFCoreExample eFCoreExample = new EFCoreExample();
            ////eFCoreExample.Read();
            //eFCoreExample.Create("something","Something"，"something");

            //string query ="[BLogAuthor]= @BlogAuthor,";
            //Console.WriteLine(query.Substring(0, query.Length - 2));

            //DapperExample2 dapperExample2 = new DapperExample2();
            //dapperExample2.Read();

            var serviceProvider = new ServiceCollection()
                .AddSingleton<AdoDotNetExample>()
                .BuildServiceProvider();

            var adoDotNetExample = serviceProvider.GetRequiredService<AdoDotNetExample>();
            adoDotNetExample.Read();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
