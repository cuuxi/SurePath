using Cuuxi.SurePath.DAL.Entities;
using Cuuxi.SurePath.DAL.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace Cuuxi.SurePath.DAL.Repositories
{
    public class UserLoginLogsRepository : BaseRepository
    {
        public UserLoginLogsRepository(Connector connector) : base(connector)
        {
        }

        public async Task<List<UserLoginLogDto>> GetByUserAsync(int userId)
            => await settings.DbContext.UserLoginLogs
                .Where(e => e.UserId == userId)
                .OrderByDescending(e => e.LoggedAt)
                .Select(e => new UserLoginLogDto
                {
                    Id = e.Id,
                    UserId = e.UserId,
                    Provider = e.Provider,
                    ProviderKey = e.ProviderKey,
                    Success = e.Success,
                    LoggedAt = e.LoggedAt
                })
                .ToListAsync();

        public async Task<UserLoginLogDto> CreateAsync(string provider, string providerKey, bool success, int? userId = null)
        {
            var entity = new UserLoginLog
            {
                UserId = userId,
                Provider = provider,
                ProviderKey = providerKey,
                Success = success,
                LoggedAt = DateTimeOffset.UtcNow
            };
            settings.DbContext.UserLoginLogs.Add(entity);
            await settings.DbContext.SaveChangesAsync();
            return new UserLoginLogDto
            {
                Id = entity.Id,
                UserId = entity.UserId,
                Provider = entity.Provider,
                ProviderKey = entity.ProviderKey,
                Success = entity.Success,
                LoggedAt = entity.LoggedAt
            };
        }
    }
}
