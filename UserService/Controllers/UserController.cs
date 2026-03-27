



using Microsoft.AspNetCore.Mvc;
using UserService.DTOs;
using UserService.Models;
using UserService.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAuthService _authService;
        public UserController(IAuthService authService)
        {
            _authService = authService;
        }
        
        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request) 
        {
            var result = _authService.Register(request);
            return  Ok(result);
        }

       
        [HttpGet("login")]
        public IActionResult Login(int id)
        {
            return Ok("Login Successful");
        }
    }
}
