using Cuuxi.SurePath.DAL.Models.DTO;

namespace Cuuxi.SurePath.Portal.DAL.Repositories
{
    public class CountriesRepository : BaseRepository
    {
        public CountriesRepository(Connector connector) : base(connector) { }

        public Task<List<CountryDto>> GetAllAsync() =>
            Connector.Dal.Countries.GetAllAsync();
    }
}
