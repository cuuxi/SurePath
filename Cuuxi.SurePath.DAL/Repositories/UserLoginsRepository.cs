using Cuuxi.SurePath.DAL.Entities;
using Cuuxi.SurePath.DAL.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace Cuuxi.SurePath.DAL.Repositories
{
    public class UserLoginsRepository : BaseRepository
    {
        public UserLoginsRepository(Connector connector) : base(connector)
        {
        }

        public async Task<UserLoginDto?> GetAsync(int id)
        {
            var entity = await settings.DbContext.UserLogins.FindAsync(id);
            return entity is null ? null : ToDto(entity);
        }

        public async Task<List<UserLoginDto>> GetByUserAsync(int userId)
            => await settings.DbContext.UserLogins
                .Where(e => e.UserId == userId)
                .Select(e => new UserLoginDto
                {
                    Id = e.Id,
                    UserId = e.UserId,
                    Provider = e.Provider,
                    ProviderKey = e.ProviderKey
                })
                .ToListAsync();

        public async Task<UserLoginDto?> FindAsync(string provider, string providerKey)
        {
            var entity = await settings.DbContext.UserLogins
                .FirstOrDefaultAsync(e => e.Provider == provider && e.ProviderKey == providerKey);
            return entity is null ? null : ToDto(entity);
        }

        public async Task<string?> GetSecretAsync(string provider, string providerKey)
            => await settings.DbContext.UserLogins
                .Where(e => e.Provider == provider && e.ProviderKey == providerKey)
                .Select(e => e.ProviderSecret)
                .FirstOrDefaultAsync();

        public async Task<UserLoginDto> CreateAsync(int userId, string provider, string providerKey, string? providerSecret = null)
        {
            var entity = new UserLogin
            {
                UserId = userId,
                Provider = provider,
                ProviderKey = providerKey,
                ProviderSecret = providerSecret
            };
            settings.DbContext.UserLogins.Add(entity);
            await settings.DbContext.SaveChangesAsync();
            return ToDto(entity);
        }

        public async Task<UserLoginDto?> UpdateSecretAsync(int id, string? providerSecret)
        {
            var entity = await settings.DbContext.UserLogins.FindAsync(id);
            if (entity is null)
                return null;

            entity.ProviderSecret = providerSecret;
            await settings.DbContext.SaveChangesAsync();
            return ToDto(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await settings.DbContext.UserLogins.FindAsync(id);
            if (entity is null)
                return false;

            settings.DbContext.UserLogins.Remove(entity);
            await settings.DbContext.SaveChangesAsync();
            return true;
        }

        private static UserLoginDto ToDto(UserLogin entity) => new()
        {
            Id = entity.Id,
            UserId = entity.UserId,
            Provider = entity.Provider,
            ProviderKey = entity.ProviderKey
        };
    }
}
