using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NETnews.Data.Services.Interfaces;
using NETnews.Models;
using System.Threading.Tasks;

namespace NETnews.Controllers {
    public class UserController : Controller {

        public readonly IUserService userService;
        public readonly UserManager<User> userManager;
        public readonly SignInManager<User> signInManager;

        public UserController(IUserService userService, UserManager<User> userManager, SignInManager<User> signInManager) {
            this.userService = userService;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Register() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register([Bind("name, username")] User user) {
            if (ModelState.IsValid) {
                try {
                    var result = await userManager.CreateAsync(user);
                    if (result.Succeeded) {
                        userService.addUser(user);
                        await signInManager.SignInAsync(user, false);
                        return RedirectToAction("Index", "News");
                    }
                    else
                        return View(user);
                } catch (UserExistsException e) {
                    ViewData["Message"] = e.Message.ToString();
                    return View(user);
                }
            }
            else
                return View(user);
        }
    }
}
