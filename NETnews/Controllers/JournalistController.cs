using Microsoft.AspNetCore.Mvc;
using NETnews.Data.Services.Interfaces;
using NETnews.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NETnews.Controllers {
    public class JournalistController : Controller {
        public readonly IJournalistService journalistService;

        public JournalistController(IJournalistService journalistService) {
            this.journalistService = journalistService;

        }
        public IActionResult Index() {
            return View();
        }

        public IActionResult sourceDetails(string source) {
            List<News> res = journalistService.getNewsBySource(source);
            return View(res);

        }

        public IActionResult journalistDetails(int id) {
            List<News> res = journalistService.getNewsByJournalist(id);
            return View(res);
        }

        public IActionResult journalistList() {
            var res = journalistService.getJournalists();
            return View(res);
        }
    }
}
