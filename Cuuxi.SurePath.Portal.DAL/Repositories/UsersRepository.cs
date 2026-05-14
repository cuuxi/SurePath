using Cuuxi.SurePath.DAL.Models.DTO;

namespace Cuuxi.SurePath.Portal.DAL.Repositories
{
    public class UsersRepository : BaseRepository
    {
        public UsersRepository(Connector connector) : base(connector) { }

        public Task<UserDto?> GetAsync(int id) =>
            Connector.Dal.Users.GetAsync(id);

        public Task<UserDto?> UpdateAsync(int id, string? firstName = null, string? lastName = null, string? countryCode = null) =>
            Connector.Dal.Users.UpdateAsync(id, firstName: firstName, lastName: lastName, countryCode: countryCode);
    }
}
