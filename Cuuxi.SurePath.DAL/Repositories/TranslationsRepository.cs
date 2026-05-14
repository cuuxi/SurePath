using Cuuxi.SurePath.DAL.Entities;
using Cuuxi.SurePath.DAL.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace Cuuxi.SurePath.DAL.Repositories
{
    public class TranslationsRepository : BaseRepository
    {
        public TranslationsRepository(Connector connector) : base(connector)
        {
        }

        public async Task<TranslationDto?> GetAsync(int id)
        {
            var entity = await settings.DbContext.Translations.FindAsync(id);
            return entity is null ? null : ToDto(entity);
        }

        public async Task<TranslationDto?> GetAsync(string languageCode, string key)
        {
            var entity = await settings.DbContext.Translations
                .FirstOrDefaultAsync(e => e.LanguageCode == languageCode && e.Key == key);
            return entity is null ? null : ToDto(entity);
        }

        public async Task<List<TranslationDto>> GetAllForLanguageAsync(string languageCode)
            => await settings.DbContext.Translations
                .Where(e => e.LanguageCode == languageCode)
                .Select(e => new TranslationDto { Id = e.Id, LanguageCode = e.LanguageCode, Key = e.Key, Value = e.Value })
                .ToListAsync();

        public async Task<List<TranslationDto>> GetAllForKeyAsync(string key)
            => await settings.DbContext.Translations
                .Where(e => e.Key == key)
                .Select(e => new TranslationDto { Id = e.Id, LanguageCode = e.LanguageCode, Key = e.Key, Value = e.Value })
                .ToListAsync();

        public async Task<Dictionary<string, string>> GetDictionaryAsync(string languageCode)
            => await settings.DbContext.Translations
                .Where(e => e.LanguageCode == languageCode)
                .ToDictionaryAsync(e => e.Key, e => e.Value);

        public async Task<TranslationDto> CreateAsync(string languageCode, string key, string value)
        {
            var entity = new Translation { LanguageCode = languageCode, Key = key, Value = value };
            settings.DbContext.Translations.Add(entity);
            await settings.DbContext.SaveChangesAsync();
            return ToDto(entity);
        }

        public async Task<TranslationDto?> UpdateAsync(int id, string? value = null)
        {
            var entity = await settings.DbContext.Translations.FindAsync(id);
            if (entity is null)
                return null;

            if (value is not null)
                entity.Value = value;

            await settings.DbContext.SaveChangesAsync();
            return ToDto(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await settings.DbContext.Translations.FindAsync(id);
            if (entity is null)
                return false;

            settings.DbContext.Translations.Remove(entity);
            await settings.DbContext.SaveChangesAsync();
            return true;
        }

        private static TranslationDto ToDto(Translation entity) => new()
        {
            Id = entity.Id,
            LanguageCode = entity.LanguageCode,
            Key = entity.Key,
            Value = entity.Value
        };
    }
}
