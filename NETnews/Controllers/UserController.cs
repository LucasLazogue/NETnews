using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NETnews.Data.Enums;
using NETnews.Data.Services.Interfaces;
using NETnews.Data.ViewData;
using NETnews.Models;
using System.Collections.Generic;
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
        public async Task<IActionResult> Register([Bind("name, UserName")] User user) {
            if (ModelState.IsValid) {
                var result = await userManager.CreateAsync(user);
                await userManager.AddToRoleAsync(user, UserRoles.User);
                if (result.Succeeded) {
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "News");
                }
                else {
                    ViewData["Message"] = user.UserName + " already exists";
                    return View(user);
                }
            }
            else
                return View(user);
        }

        public IActionResult Login() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserVD user) { 
            if(ModelState.IsValid) {
                string name = user.UserName.ToUpper().Normalize();
                var result = await userManager.FindByNameAsync(user.UserName.ToUpper().Normalize());

                if (result != null) {
                    await signInManager.SignInAsync(result, false);
                    return RedirectToAction("Index", "News");

                }
            }
            ViewData["message"] = "Wrong Data!";
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Logout() { 
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "News");
        
        }

        public async Task<IActionResult> Details(string id) {
            User user = userService.getUserById(id);
            UserCommentsVD ucVD = new UserCommentsVD(){
                userId = id,
                name = user.name,
                comments = userService.getUserComments(id),
            };
            return View(ucVD);
        }

        public IActionResult userList() {
            List<User> res = userService.getUsers();
            return View(res);
        }
    }
}
