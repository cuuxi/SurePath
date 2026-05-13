using Cuuxi.SurePath.DAL.Entities;
using Cuuxi.SurePath.DAL.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace Cuuxi.SurePath.DAL.Repositories
{
    public class TranslationKeysRepository : BaseRepository
    {
        public TranslationKeysRepository(Connector connector) : base(connector)
        {
        }

        public async Task<TranslationKeyDto?> GetAsync(string key)
        {
            var entity = await settings.DbContext.TranslationKeys.FindAsync(key);
            return entity is null ? null : ToDto(entity);
        }

        public async Task<List<TranslationKeyDto>> GetAllAsync()
            => await settings.DbContext.TranslationKeys
                .OrderBy(e => e.Key)
                .Select(e => new TranslationKeyDto { Key = e.Key, Description = e.Description })
                .ToListAsync();

        public async Task<TranslationKeyDto> CreateAsync(string key, string? description = null)
        {
            var entity = new TranslationKey { Key = key, Description = description };
            settings.DbContext.TranslationKeys.Add(entity);
            await settings.DbContext.SaveChangesAsync();
            return ToDto(entity);
        }

        public async Task<TranslationKeyDto?> UpdateAsync(string key, string? description = null)
        {
            var entity = await settings.DbContext.TranslationKeys.FindAsync(key);
            if (entity is null)
                return null;

            entity.Description = description;
            await settings.DbContext.SaveChangesAsync();
            return ToDto(entity);
        }

        public async Task<bool> DeleteAsync(string key)
        {
            var entity = await settings.DbContext.TranslationKeys.FindAsync(key);
            if (entity is null)
                return false;

            settings.DbContext.TranslationKeys.Remove(entity);
            await settings.DbContext.SaveChangesAsync();
            return true;
        }

        private static TranslationKeyDto ToDto(TranslationKey entity) => new()
        {
            Key = entity.Key,
            Description = entity.Description
        };
    }
}
