using Cuuxi.SurePath.DAL.Models.DTO;

namespace Cuuxi.SurePath.Backend.DAL.Repositories
{
    public class TranslationsRepository : BaseRepository
    {
        public TranslationsRepository(Connector connector) : base(connector) { }

        public Task<TranslationDto?> GetAsync(string languageCode, string key) =>
            Connector.Dal.Translations.GetAsync(languageCode, key);

        public Task<List<TranslationDto>> GetAllForKeyAsync(string key) =>
            Connector.Dal.Translations.GetAllForKeyAsync(key);

        public Task<Dictionary<string, string>> GetDictionaryAsync(string languageCode) =>
            Connector.Dal.Translations.GetDictionaryAsync(languageCode);

        public Task<Dictionary<string, string>> GetDictionaryByPrefixAsync(string languageCode, string keyPrefix) =>
            Connector.Dal.Translations.GetDictionaryByPrefixAsync(languageCode, keyPrefix);

        public Task<TranslationDto> CreateAsync(string languageCode, string key, string value) =>
            Connector.Dal.Translations.CreateAsync(languageCode, key, value);

        public Task<TranslationDto?> UpdateAsync(int id, string? value = null) =>
            Connector.Dal.Translations.UpdateAsync(id, value);
    }
}
