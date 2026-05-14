using Cuuxi.SurePath.DAL.Models.DTO;

namespace Cuuxi.SurePath.Portal.DAL.Repositories
{
    public class UserLoginLogsRepository : BaseRepository
    {
        public UserLoginLogsRepository(Connector connector) : base(connector) { }

        public Task<UserLoginLogDto> CreateAsync(string provider, string providerKey, bool success, int? userId = null) =>
            Connector.Dal.UserLoginLogs.CreateAsync(provider, providerKey, success, userId);
    }
}
