using Cuuxi.SurePath.DAL.Entities;
using Cuuxi.SurePath.DAL.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace Cuuxi.SurePath.DAL.Repositories
{
    public class LanguagesRepository : BaseRepository
    {
        public LanguagesRepository(Connector connector) : base(connector)
        {
        }

        public async Task<LanguageDto?> GetAsync(string code)
        {
            var entity = await settings.DbContext.Languages.FindAsync(code);
            return entity is null ? null : ToDto(entity);
        }

        public async Task<List<LanguageDto>> GetAllAsync()
            => await settings.DbContext.Languages
                .Select(e => new LanguageDto { Code = e.Code, Name = e.Name, IsActive = e.IsActive })
                .ToListAsync();

        public async Task<List<LanguageDto>> GetAllActiveAsync()
            => await settings.DbContext.Languages
                .Where(e => e.IsActive)
                .Select(e => new LanguageDto { Code = e.Code, Name = e.Name, IsActive = e.IsActive })
                .ToListAsync();

        public async Task<LanguageDto> CreateAsync(string code, string name, bool isActive = true)
        {
            var entity = new Language { Code = code, Name = name, IsActive = isActive };
            settings.DbContext.Languages.Add(entity);
            await settings.DbContext.SaveChangesAsync();
            return ToDto(entity);
        }

        public async Task<LanguageDto?> UpdateAsync(string code, string? name = null, bool? isActive = null)
        {
            var entity = await settings.DbContext.Languages.FindAsync(code);
            if (entity is null)
                return null;

            if (name is not null)
                entity.Name = name;
            if (isActive.HasValue)
                entity.IsActive = isActive.Value;

            await settings.DbContext.SaveChangesAsync();
            return ToDto(entity);
        }

        private static LanguageDto ToDto(Language entity) => new()
        {
            Code = entity.Code,
            Name = entity.Name,
            IsActive = entity.IsActive
        };
    }
}
