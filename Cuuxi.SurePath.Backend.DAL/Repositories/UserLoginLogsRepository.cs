using Cuuxi.SurePath.DAL.Models.DTO;

namespace Cuuxi.SurePath.Backend.DAL.Repositories
{
    public class UserLoginLogsRepository : BaseRepository
    {
        public UserLoginLogsRepository(Connector connector) : base(connector) { }

        public Task<List<UserLoginLogDto>> GetByUserAsync(int userId) =>
            Connector.Dal.UserLoginLogs.GetByUserAsync(userId);
    }
}
