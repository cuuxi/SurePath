using Cuuxi.SurePath.DAL.Entities;
using Cuuxi.SurePath.DAL.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace Cuuxi.SurePath.DAL.Repositories
{
    public class UsersRepository : BaseRepository
    {
        public UsersRepository(Connector connector) : base(connector)
        {
        }

        public async Task<UserDto?> GetAsync(int id)
        {
            var entity = await settings.DbContext.Users.FindAsync(id);
            return entity is null ? null : ToDto(entity);
        }

        public async Task<List<UserDto>> GetAllAsync()
            => await settings.DbContext.Users
                .Select(e => new UserDto
                {
                    Id = e.Id,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    IsActive = e.IsActive,
                    CountryCode = e.CountryCode
                })
                .ToListAsync();

        public async Task<UserDto> CreateAsync(string firstName, string lastName, string countryCode, bool isActive = true)
        {
            var entity = new User
            {
                FirstName = firstName,
                LastName = lastName,
                CountryCode = countryCode,
                IsActive = isActive
            };
            settings.DbContext.Users.Add(entity);
            await settings.DbContext.SaveChangesAsync();
            return ToDto(entity);
        }

        public async Task<UserDto?> UpdateAsync(int id, string? firstName = null, string? lastName = null, bool? isActive = null, string? countryCode = null)
        {
            var entity = await settings.DbContext.Users.FindAsync(id);
            if (entity is null)
                return null;

            if (firstName is not null)
                entity.FirstName = firstName;
            if (lastName is not null)
                entity.LastName = lastName;
            if (isActive.HasValue)
                entity.IsActive = isActive.Value;
            if (countryCode is not null)
                entity.CountryCode = countryCode;

            await settings.DbContext.SaveChangesAsync();
            return ToDto(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await settings.DbContext.Users.FindAsync(id);
            if (entity is null)
                return false;

            settings.DbContext.Users.Remove(entity);
            await settings.DbContext.SaveChangesAsync();
            return true;
        }

        private static UserDto ToDto(User entity) => new()
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            IsActive = entity.IsActive,
            CountryCode = entity.CountryCode
        };
    }
}
