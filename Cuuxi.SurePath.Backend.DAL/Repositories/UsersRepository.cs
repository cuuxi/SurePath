using Cuuxi.SurePath.DAL.Models.DTO;

namespace Cuuxi.SurePath.Backend.DAL.Repositories
{
    public class UsersRepository : BaseRepository
    {
        public UsersRepository(Connector connector) : base(connector) { }

        public Task<UserDto?> GetAsync(int id) => Connector.Dal.Users.GetAsync(id);
        public Task<List<UserDto>> GetAllAsync() => Connector.Dal.Users.GetAllAsync();
    }
}
