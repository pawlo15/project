using Microsoft.AspNetCore.Mvc;
using Project.Infrastructure.DTOs.User;
using Project.Infrastructure.Models.User;
using Project.Infrastructure.Models;
using Project.Infrastructure.Services.Interfaces.Base;

namespace Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        public readonly IAuthenticationService _authenticationService;

        public AuthController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("registration")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegisterDto userRegister)
        {
            var response = await _authenticationService.Register(
                new User { Login = userRegister.Login}, userRegister.Password);
            if(response.Message == string.Empty)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(UserLoginDto userLogin)
        {
            var response = await _authenticationService.Login(userLogin.UserName, userLogin.Password);
            if(response.Message == string.Empty)
                return Ok(response);
            return BadRequest(response);
        }
    }
}
