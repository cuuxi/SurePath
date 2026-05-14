using Cuuxi.SurePath.DAL.Models.DTO;

namespace Cuuxi.SurePath.Portal.BLL.Services
{
    public class UserService : BaseService
    {
        public UserService(Connector connector) : base(connector) { }

        public Task<UserLoginDto?> FindLoginAsync(string provider, string username) =>
            Connector.DAL.UserLogins.FindAsync(provider, username);

        public async Task<bool> VerifyPasswordAsync(string provider, string username, string password)
        {
            var secret = await Connector.DAL.UserLogins.GetSecretAsync(provider, username);
            return secret is not null && BCrypt.Net.BCrypt.Verify(password, secret);
        }

        public Task LogLoginAttemptAsync(string provider, string username, bool success, int? userId = null) =>
            Connector.DAL.UserLoginLogs.CreateAsync(provider, username, success, userId);

        public Task<UserDto?> GetAsync(int id) =>
            Connector.DAL.Users.GetAsync(id);

        public Task<UserDto?> UpdateAsync(int id, string? firstName = null, string? lastName = null, string? countryCode = null) =>
            Connector.DAL.Users.UpdateAsync(id, firstName: firstName, lastName: lastName, countryCode: countryCode);

        public Task<List<CountryDto>> GetCountriesAsync() =>
            Connector.DAL.Countries.GetAllAsync();
    }
}
