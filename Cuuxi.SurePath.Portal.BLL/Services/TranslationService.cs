namespace Cuuxi.SurePath.Portal.BLL.Services
{
    public class TranslationService : BaseService
    {
        public TranslationService(Connector connector) : base(connector) { }

        public Task<Dictionary<string, string>> GetDictionaryAsync(string languageCode) =>
            Connector.DAL.Translations.GetDictionaryByPrefixAsync(languageCode, "portal.");
    }
}
