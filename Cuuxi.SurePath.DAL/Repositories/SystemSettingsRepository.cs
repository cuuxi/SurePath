using Cuuxi.SurePath.DAL.Entities;
using Cuuxi.SurePath.DAL.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace Cuuxi.SurePath.DAL.Repositories
{
    public class SystemSettingsRepository : BaseRepository
    {
        public SystemSettingsRepository(Connector connector) : base(connector)
        {
        }

        public async Task<SystemSettingDto?> GetAsync(int id)
        {
            var entity = await settings.DbContext.SystemSettings.FindAsync(id);
            return entity is null ? null : ToDto(entity);
        }

        public async Task<List<SystemSettingDto>> GetAllAsync()
            => await settings.DbContext.SystemSettings
                .Select(e => new SystemSettingDto { Id = e.Id, UpdatedAt = e.UpdatedAt })
                .ToListAsync();

        public async Task<SystemSettingDto> CreateAsync(DateTimeOffset? updatedAt = null)
        {
            var entity = new SystemSetting
            {
                UpdatedAt = updatedAt ?? DateTimeOffset.UtcNow
            };
            settings.DbContext.SystemSettings.Add(entity);
            await settings.DbContext.SaveChangesAsync();
            return ToDto(entity);
        }

        public async Task<SystemSettingDto?> UpdateAsync(int id, DateTimeOffset? updatedAt = null)
        {
            var entity = await settings.DbContext.SystemSettings.FindAsync(id);
            if (entity is null)
                return null;

            if (updatedAt.HasValue)
                entity.UpdatedAt = updatedAt.Value;

            await settings.DbContext.SaveChangesAsync();
            return ToDto(entity);
        }

        private static SystemSettingDto ToDto(SystemSetting entity) => new()
        {
            Id = entity.Id,
            UpdatedAt = entity.UpdatedAt
        };
    }
}
