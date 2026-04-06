using Microsoft.AspNetCore.Mvc;

namespace THSDotNetCore.Project1.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetBlogs()
        {
            var blogs = new List<BlogModel>
            {
                new BlogModel { BlogId = 1, BlogTitle = "Welcome", BlogAuthor = "Yurina", BlogContent = " Welcome welcome" },
                new BlogModel { BlogId = 2, BlogTitle = "Meow", BlogAuthor = "Yuyu", BlogContent = "Orange" },
                new BlogModel { BlogId = 3, BlogTitle = "NeiKos496", BlogAuthor = "Lygus", BlogContent = "Flame Reaver" }
            };

            return Ok(blogs);
        }
    }

    public class BlogModel
    {
        public int BlogId { get; set; }
        public string? BlogTitle { get; set; }
        public string? BlogAuthor { get; set; }
        public string? BlogContent { get; set; }
    }
}
