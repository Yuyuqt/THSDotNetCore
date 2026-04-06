using Microsoft.AspNetCore.Mvc;
using THSDotNetCore.Database.Models;
using THSDotNetCore.Domain.Features;
using THSDotNetCore.MvcApp.Models;

namespace THSDotNetCore.MvcApp.Controllers
{
    public class BlogAjaxController : Controller
    {
        private readonly BlogService _blogService;

        public BlogAjaxController(BlogService blogService)
        {
            _blogService = blogService;
        }
        [ActionName("Index")]
        public IActionResult BlogList()
        {
            var lst = _blogService.GetBlogs();
            return View("BlogList", lst);
        }

        
        [ActionName("List")]
        public IActionResult BlogListAjax()
        {
            var lst = _blogService.GetBlogs();
            return Json(lst);
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
            MessageModel model;
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

                model = new MessageModel(true, "Blog created successfully.");
                
                }
            catch (Exception ex)
            {
                //ViewBag.IsSuccess = false;
                //ViewBag.Message = ex.ToString();

                TempData["IsSuccess"] = false;
                TempData["Message"] = ex.ToString();
                model = new MessageModel(false, ex.ToString());

            }

            return Json(model);

            //var lst = _blogService.GetBlogs();
            //return View("Index", lst);
        }

        public class MessageModel
        {
            public MessageModel()
            {
            }
            public MessageModel(bool isSuccess, string message)
            {
                IsSuccess = isSuccess;
                Message = message;
            }
            public bool IsSuccess { get; set; }
            public string Message { get; set; }
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
            MessageModel model;
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
                    model = new MessageModel(true, "Blog updated successfully.");
                }
                else
                {
                    model = new MessageModel(false, "Update failed.");
                }
            }
            catch (Exception ex)
            {
                model = new MessageModel(false, ex.ToString());
            }
            return Json(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult BlogDelete(int id)
        {
            MessageModel model;
            try
            {
                var result = _blogService.DeleteBlog(id);
                if (result > 0)
                {
                    model = new MessageModel(true, "Blog deleted successfully.");
                }
                else
                {
                    model = new MessageModel(false, "Delete failed.");
                }
            }
            catch (Exception ex)
            {
                model = new MessageModel(false, ex.ToString());
            }
            return Json(model);
        }
    }
}


 