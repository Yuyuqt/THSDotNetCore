using Microsoft.AspNetCore.Mvc;
using THSDotNetCore.Project1.MvcApp.Models;
using THSDotNetCore.Shared;

namespace THSDotNetCore.Project1.MvcApp.Controllers
{
    public class BlogController : Controller
    {
        private readonly IHttpClientService _httpClientService;
        private readonly ILogger<BlogController> _logger;

        public BlogController(IHttpClientService httpClientService, ILogger<BlogController> logger)
        {
            _httpClientService = httpClientService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("Fetching blog list from API...");
            var lst = await _httpClientService.GetAsync<List<BlogModel>>("api/blogs");
            _logger.LogInformation("Found {Count} blogs.", lst?.Count ?? 0);
            return View(lst);
        }
    }
}
