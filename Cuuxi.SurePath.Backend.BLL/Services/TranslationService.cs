using Cuuxi.SurePath.DAL.Models.DTO;

namespace Cuuxi.SurePath.Backend.BLL.Services
{
    public class TranslationService : BaseService
    {
        public TranslationService(Connector connector) : base(connector) { }

        public Task<Dictionary<string, string>> GetDictionaryAsync(string languageCode) =>
            Connector.DAL.Translations.GetDictionaryAsync(languageCode);

        public Task<List<TranslationKeyDto>> GetAllKeysAsync() =>
            Connector.DAL.TranslationKeys.GetAllAsync();

        public Task<TranslationKeyDto?> GetKeyAsync(string key) =>
            Connector.DAL.TranslationKeys.GetAsync(key);

        public Task CreateKeyAsync(string key, string? description) =>
            Connector.DAL.TranslationKeys.CreateAsync(key, description);

        public Task<List<LanguageDto>> GetActiveLanguagesAsync() =>
            Connector.DAL.Languages.GetAllActiveAsync();

        public Task<List<TranslationDto>> GetTranslationsForKeyAsync(string key) =>
            Connector.DAL.Translations.GetAllForKeyAsync(key);

        public async Task SaveAsync(string key, Dictionary<string, string?> values)
        {
            foreach (var (languageCode, value) in values)
            {
                var existing = await Connector.DAL.Translations.GetAsync(languageCode, key);
                if (existing is null)
                    await Connector.DAL.Translations.CreateAsync(languageCode, key, value ?? string.Empty);
                else
                    await Connector.DAL.Translations.UpdateAsync(existing.Id, value ?? string.Empty);
            }
        }
    }
}
