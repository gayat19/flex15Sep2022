using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPizzaAPI.Models;
using MyPizzaAPI.Services;

namespace MyPizzaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }
        [HttpPost("Login")]
        public IActionResult Login(User user)
        {
            var userObj = _userService.Login(user);
            if (userObj == null)
                return BadRequest("Invalid username or password");
            return Ok(userObj);
        }
        [HttpPost("Register")]
        public IActionResult Register(User user)
        {
            var userObj = _userService.Register(user);
            if (userObj == null)
                return BadRequest("Unable to register user");
            return Ok(userObj);
        }
    }
}
