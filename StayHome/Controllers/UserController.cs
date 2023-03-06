using BusinessLogicLayer.Service;
using BusinessLogicLayer.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StayHome.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserVM newAccount)
        {
           
            return Ok(_userService.addUser(newAccount));
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserVM account)
        {

            return Ok(_userService.Login(account));
        }
    }
}
