using Cuuxi.SurePath.DAL.Models.DTO;

namespace Cuuxi.SurePath.Backend.DAL.Repositories
{
    public class LanguagesRepository : BaseRepository
    {
        public LanguagesRepository(Connector connector) : base(connector) { }

        public Task<List<LanguageDto>> GetAllActiveAsync() =>
            Connector.Dal.Languages.GetAllActiveAsync();
    }
}
