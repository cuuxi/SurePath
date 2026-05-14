using Cuuxi.SurePath.API.BLL;
using Cuuxi.SurePath.API.Models.Requests;
using Cuuxi.SurePath.DAL.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Cuuxi.SurePath.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly Connector _connector;

        public UsersController(Connector connector)
        {
            _connector = connector;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserDto>> GetAsync(int id)
        {
            var user = await _connector.Users.GetAsync(id);
            return user is null ? NotFound() : Ok(user);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<UserDto>> UpdateAsync(int id, [FromBody] UpdateUserRequest request)
        {
            var user = await _connector.Users.UpdateAsync(id, request.FirstName, request.LastName, request.CountryCode);
            return user is null ? NotFound() : Ok(user);
        }
    }
}
