using Microsoft.AspNetCore.Mvc;
using MyFirstWebApp.Models;
using MyFirstWebApp.Models.DTOs;
using MyFirstWebApp.Services;

namespace MyFirstWebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            var result = await _userService.Register(user);
            if(result != null)
            {
                HttpContext.Session.SetString("token", ((UserDTO)result).Token);
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Error = "Unable to register user";
            return View();
        }
    }
}
