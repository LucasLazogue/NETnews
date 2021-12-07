using Microsoft.AspNetCore.Mvc;
using NETnews.Data.Services;
using NETnews.Models;
using RestSharp;
using System.Linq;
using System.Threading.Tasks;

namespace NETnews.Controllers {
    public class NewsController : Controller {

        public readonly INewsService newsService;

        public NewsController(INewsService newsService) {
            this.newsService = newsService;
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
    }
}
