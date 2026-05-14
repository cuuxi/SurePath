using Microsoft.EntityFrameworkCore;

namespace Cuuxi.SurePath.Web.DAL.Repositories
{
    public class TranslationsRepository : BaseRepository
    {
        public TranslationsRepository(Connector connector) : base(connector) { }

        public Task<Dictionary<string, string>> GetDictionaryByPrefixAsync(string languageCode, string keyPrefix) =>
            settings.DbContext.Translations
                .Where(e => e.LanguageCode == languageCode && e.Key.StartsWith(keyPrefix))
                .ToDictionaryAsync(e => e.Key, e => e.Value);
    }
}
