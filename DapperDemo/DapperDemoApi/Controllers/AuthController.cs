using Microsoft.AspNetCore.Mvc;
using DapperDemoApi.Services;


namespace DapperDemoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = _authService.AuthenticateUser(request.Name, request.Email);
            if (user != null)
            {
                var token = _authService.GenerateToken(user);
                return Ok(new { Token = token });
            }
            return Unauthorized();
        }
    }

    public class LoginRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}

