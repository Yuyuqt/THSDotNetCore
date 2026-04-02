using Microsoft.AspNetCore.Mvc;
using THSDotNetCore.Database.Models;
using THSDotNetCore.Domain.Features;
using THSDotNetCore.MvcApp.Models;

namespace THSDotNetCore.MvcApp.Controllers
{
    public class BlogController : Controller
    {
        private readonly BlogService _blogService;

        public BlogController(BlogService blogService)
        {
            _blogService = blogService;
        }
        public IActionResult Index()
        {
            var lst = _blogService.GetBlogs();
            return View(lst);
        }

        [ActionName("Create")]
        public IActionResult BlogCreate()
        {
            return View("BlogCreate");
        }

        [HttpPost]
        [ActionName("Save")]
        public IActionResult BlogSave(BlogRequestModel requestModel)
        {
            try
            {
                _blogService.CreateBlog(new TblBlog
                {
                    BlogTitle = requestModel.Title,
                    BlogAuthor = requestModel.Author,
                    BlogContent = requestModel.Content,
                });

                //ViewBag.IsSuccess = true;
                //ViewBag.Message = "Blog created successfully.";

                TempData["IsSuccess"] = true;
                TempData["Message"] = "Blog created successfully.";
            }
            catch (Exception ex)
            {
                //ViewBag.IsSuccess = false;
                //ViewBag.Message = ex.ToString();

                TempData["IsSuccess"] = false;
                TempData["Message"] = ex.ToString();
            }
            return RedirectToAction("Index");

            //var lst = _blogService.GetBlogs();
            //return View("Index", lst);
        }

        [ActionName("Edit")]
        public IActionResult BlogEdit(int id)
        {
            var blog = _blogService.GetBlog(id);
            if (blog == null)
            {
                return RedirectToAction("Index");
            }
            return View("BlogEdit", blog);
        }

        [HttpPost]
        [ActionName("Update")]
        public IActionResult BlogUpdate(int id, BlogRequestModel requestModel)
        {
            try
            {
                var blog = new TblBlog
                {
                    BlogTitle = requestModel.Title,
                    BlogAuthor = requestModel.Author,
                    BlogContent = requestModel.Content
                };

                var result = _blogService.UpdateBlog(id, blog);
                if (result > 0)
                {
                    TempData["IsSuccess"] = true;
                    TempData["Message"] = "Blog updated successfully.";
                }
                else
                {
                    TempData["IsSuccess"] = false;
                    TempData["Message"] = "Update failed.";
                }
            }
            catch (Exception ex)
            {
                TempData["IsSuccess"] = false;
                TempData["Message"] = ex.ToString();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
          
            _blogService.DeleteBlog(id);
            return RedirectToAction("Index");
        }
    }
}

    
