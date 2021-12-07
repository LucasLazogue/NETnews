using Microsoft.AspNetCore.Mvc;
using NETnews.Data.Services.Interfaces;
using NETnews.Models;
using System.Threading.Tasks;

namespace NETnews.Controllers {
    public class UserController : Controller {

        public readonly IUserService userService;

        public UserController(IUserService userService) {
            this.userService = userService;
        }
        public IActionResult Register() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register([Bind("name, username")] User user) {
            if(!ModelState.IsValid) {
                return View(user);
            }
            try {
                userService.addUser(user);
                return RedirectToAction("Index", "News");
            } catch (UserExistsException e) {
                ViewData["Message"] = e.Message.ToString();
                return View(user);
            }

        }
    }
}
