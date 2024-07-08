using ElasticSearch.Web.Models;
using ElasticSearch.Web.Services;
using ElasticSearch.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ElasticSearch.Web.Controllers
{
    public class BlogController : Controller
    {
        private readonly BlogService _blogService;
        public BlogController(BlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet]
        public async Task<IActionResult> Search()
        {
            return View(await _blogService.SearchAsync(string.Empty));
        }
        [HttpPost]
        public async Task<IActionResult> Search(string searchText)
        {
            ViewBag.searchText = searchText;
            return View(await _blogService.SearchAsync(searchText));
        }
        public IActionResult Save()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Save(CreatedBlogViewModel newBlog)
        {
            var isSuccess = await _blogService.SaveAsync(newBlog);
            if (!isSuccess)
            {
                TempData["result"] = "Kayıt başarısız";
                return RedirectToAction(nameof(Save));
            }
            TempData["result"] = "Kayıt başarılı";
            return RedirectToAction(nameof(Save));
        }
    }
}
