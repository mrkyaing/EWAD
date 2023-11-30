using CloudPOSAPI.Models;
using CloudPOSAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace CloudPOSAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenServices _jwttokenservice;

        public AuthController(ITokenServices jWTTokenServices)
        {
            _jwttokenservice = jWTTokenServices;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var user = new UserModel()
            {
                Username = HttpContext.User.Claims.First(i => i.Type == ClaimTypes.NameIdentifier).Value,
                Role = HttpContext.User.Claims.First(i => i.Type == ClaimTypes.Role).Value
            };
            return Ok(user);
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Auth(UserModel user)
        {
            var auser = _jwttokenservice.Authenticate(user);
            if (auser != null)
            {
                var token = _jwttokenservice.GenerateToken(user);
                return Ok(token);
            }
             return NotFound("user not found");
        }
    }
}
