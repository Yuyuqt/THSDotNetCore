using Microsoft.AspNetCore.Mvc;
using THSDotNetCore.Database.Models;
using THSDotNetCore.Domain.Features;

namespace THSDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogServiceController : ControllerBase
    {
        private readonly BlogService _blogService;

        public BlogServiceController() {
            _blogService = new BlogService();
        }

        [HttpGet]
        public IActionResult GetBlogs()
        {
            var lst = _blogService.GetBlogs();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
            var item = _blogService.GetBlog(id);
            if (item is null)
            {
                return NotFound("No data found.");
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateBlog(TblBlog blog)
        {
            int result = _blogService.CreateBlog(blog);
            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, TblBlog blog)
        {
            int result = _blogService.UpdateBlog(id, blog);
            string message = result > 0 ? "Updating Successful." : "Updating Failed.";
            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id, TblBlog blog)
        {
            int result = _blogService.PatchBlog(id, blog);
            string message = result > 0 ? "Patching Successful." : "Patching Failed.";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            int result = _blogService.DeleteBlog(id);
            string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";
            return Ok(message);
        }
    }
}
