using Cuuxi.SurePath.DAL.Models.DTO;

namespace Cuuxi.SurePath.Backend.DAL.Repositories
{
    public class TranslationKeysRepository : BaseRepository
    {
        public TranslationKeysRepository(Connector connector) : base(connector) { }

        public Task<TranslationKeyDto?> GetAsync(string key) =>
            Connector.Dal.TranslationKeys.GetAsync(key);

        public Task<List<TranslationKeyDto>> GetAllAsync() =>
            Connector.Dal.TranslationKeys.GetAllAsync();

        public Task<TranslationKeyDto> CreateAsync(string key, string? description = null) =>
            Connector.Dal.TranslationKeys.CreateAsync(key, description);
    }
}
