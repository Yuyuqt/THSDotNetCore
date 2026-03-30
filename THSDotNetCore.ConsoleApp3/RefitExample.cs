using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;



namespace THSDotNetCore.ConsoleApp3
{
    internal class RefitExample
    {
        public async Task Run()
        {
            var blogApi = RestService.For<IBlogApi>("https://localhost:7058");

            var lst = await blogApi.GetBlogs();

            foreach (var item in lst)
            {
                Console.WriteLine(item.BlogTitle);
            }

            var item2 = await blogApi.GetBlog(1);
            try
            {
                var item3 = await blogApi.GetBlog(100);

            }
            catch (ApiException ex)
            {
                if(ex.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine("Blog not found");
                }
            }
           
            var item4 = await blogApi.CreateBlog(new BlogModel()
            {
                BlogTitle = "Refit test",
                BlogAuthor = "THS refit",
                BlogContent = "Refit test"
            });
             //Console.WriteLine($"Yeni blog oluşturuldu. ID: {item4.BlogId}");   
        }
    }
}
