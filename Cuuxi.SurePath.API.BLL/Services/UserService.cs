using Cuuxi.SurePath.DAL.Models.DTO;

namespace Cuuxi.SurePath.API.BLL.Services
{
    public class UserService : BaseService
    {
        public UserService(Connector connector) : base(connector) { }

        public async Task<(bool Success, UserDto? User, string ErrorType)> LoginAsync(string provider, string username, string password)
        {
            var login = await Connector.DAL.UserLogins.FindAsync(provider, username);

            if (login is null)
            {
                await Connector.DAL.UserLoginLogs.CreateAsync(provider, username, success: false);
                return (false, null, "invalid");
            }

            var secret = await Connector.DAL.UserLogins.GetSecretAsync(provider, username);
            var valid = secret is not null && BCrypt.Net.BCrypt.Verify(password, secret);

            if (!valid)
            {
                await Connector.DAL.UserLoginLogs.CreateAsync(provider, username, success: false, userId: login.UserId);
                return (false, null, "invalid");
            }

            var user = await Connector.DAL.Users.GetAsync(login.UserId);

            if (user is null || !user.IsActive)
            {
                await Connector.DAL.UserLoginLogs.CreateAsync(provider, username, success: false, userId: login.UserId);
                return (false, null, "inactive");
            }

            await Connector.DAL.UserLoginLogs.CreateAsync(provider, username, success: true, userId: user.Id);
            return (true, user, string.Empty);
        }

        public Task<UserDto?> GetAsync(int id) =>
            Connector.DAL.Users.GetAsync(id);

        public Task<UserDto?> UpdateAsync(int id, string? firstName = null, string? lastName = null, string? countryCode = null) =>
            Connector.DAL.Users.UpdateAsync(id, firstName: firstName, lastName: lastName, countryCode: countryCode);

        public Task<List<CountryDto>> GetCountriesAsync() =>
            Connector.DAL.Countries.GetAllAsync();
    }
}
