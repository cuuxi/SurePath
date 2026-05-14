using Cuuxi.SurePath.API.BLL;
using Cuuxi.SurePath.API.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Cuuxi.SurePath.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly Connector _connector;

        public AuthController(Connector connector)
        {
            _connector = connector;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest request)
        {
            var (success, user, errorType) = await _connector.Users.LoginAsync(request.Provider, request.Username, request.Password);

            if (!success)
                return Ok(new { success = false, errorType });

            return Ok(new
            {
                success = true,
                userId = user!.Id,
                firstName = user.FirstName,
                lastName = user.LastName
            });
        }
    }
}
