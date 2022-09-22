using AuthenticationWithBearerAndJWT.Models;
using AuthenticationWithBearerAndJWT.Repositories;
using AuthenticationWithBearerAndJWT.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationWithBearerAndJWT.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public ActionResult<dynamic> Authenticate([FromServices] IConfiguration config, [FromBody] LoginViewModel model)
        {
            var user = UserRepository.Get(model.Login, model.Password);

            if (user == null)
                return NotFound(new { message = "User or password invalid." });

            var userToken = new UserToken()
            {
                Id = user.Id,
                Role = user.Role,
                Username = user.Username,
                Email = user.Email
            };

            var token = TokenService.GenerateToken(config, userToken);

            return new
            {
                userToken,
                token
            };
        }

    }
}
