using Cuuxi.SurePath.DAL.Entities;
using Cuuxi.SurePath.DAL.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace Cuuxi.SurePath.DAL.Repositories
{
    public class CountriesRepository : BaseRepository
    {
        public CountriesRepository(Connector connector) : base(connector)
        {
        }

        public async Task<CountryDto?> GetAsync(string code)
        {
            var entity = await settings.DbContext.Countries.FindAsync(code);
            return entity is null ? null : ToDto(entity);
        }

        public async Task<List<CountryDto>> GetAllAsync()
            => await settings.DbContext.Countries
                .Select(e => new CountryDto { Code = e.Code, Name = e.Name, LanguageCode = e.LanguageCode })
                .ToListAsync();

        public async Task<CountryDto> CreateAsync(string code, string name, string languageCode)
        {
            var entity = new Country { Code = code, Name = name, LanguageCode = languageCode };
            settings.DbContext.Countries.Add(entity);
            await settings.DbContext.SaveChangesAsync();
            return ToDto(entity);
        }

        public async Task<CountryDto?> UpdateAsync(string code, string? name = null, string? languageCode = null)
        {
            var entity = await settings.DbContext.Countries.FindAsync(code);
            if (entity is null)
                return null;

            if (name is not null)
                entity.Name = name;
            if (languageCode is not null)
                entity.LanguageCode = languageCode;

            await settings.DbContext.SaveChangesAsync();
            return ToDto(entity);
        }

        private static CountryDto ToDto(Country entity) => new()
        {
            Code = entity.Code,
            Name = entity.Name,
            LanguageCode = entity.LanguageCode
        };
    }
}
