using Cuuxi.SurePath.DAL.Models.DTO;

namespace Cuuxi.SurePath.Backend.BLL.Services
{
    public class UserService : BaseService
    {
        public UserService(Connector connector) : base(connector) { }

        public Task<List<UserDto>> GetAllAsync() =>
            Connector.DAL.Users.GetAllAsync();

        public Task<UserDto?> GetAsync(int id) =>
            Connector.DAL.Users.GetAsync(id);

        public Task<List<UserLoginLogDto>> GetLoginLogsAsync(int userId) =>
            Connector.DAL.UserLoginLogs.GetByUserAsync(userId);
    }
}
