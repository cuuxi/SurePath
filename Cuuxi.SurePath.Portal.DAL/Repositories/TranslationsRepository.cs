namespace Cuuxi.SurePath.Portal.DAL.Repositories
{
    public class TranslationsRepository : BaseRepository
    {
        public TranslationsRepository(Connector connector) : base(connector) { }

        public Task<Dictionary<string, string>> GetDictionaryByPrefixAsync(string languageCode, string keyPrefix) =>
            Connector.Dal.Translations.GetDictionaryByPrefixAsync(languageCode, keyPrefix);
    }
}
