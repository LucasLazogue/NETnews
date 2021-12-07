using Microsoft.AspNetCore.Mvc;
using NETnews.Data.Services;
using RestSharp;
using System.Linq;

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
    }
}
