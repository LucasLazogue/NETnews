using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NETnews.Data.Services;
using NETnews.Data.ViewData;
using NETnews.Models;
using RestSharp;
using System.Linq;
using System.Threading.Tasks;

namespace NETnews.Controllers {
    public class NewsController : Controller {

        public readonly INewsService newsService;
        public readonly SignInManager<User> signInManager;

        public NewsController(INewsService newsService, SignInManager<User> signInManager) {
            this.newsService = newsService;
            this.signInManager = signInManager;
        }
        public IActionResult Index() {
                newsService.loadNews();
                return View(newsService.getAll());
         }
        public async Task<IActionResult> Details(int id) {

            try {
                News news = newsService.getNewsById(id);
                return View(news);
            } catch (NewsNotExistsException e) {
                ViewData["Message"] = e.Message.ToString();
                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Comment(CommentVD comment) {
            if (comment.text.Length > 0) 
                newsService.addComment(comment);

            else 
                ViewData["Message"] = "Comment has to have at least one char";
            return RedirectToAction("Details", new { id = comment.idNews });

        }
    }
}
