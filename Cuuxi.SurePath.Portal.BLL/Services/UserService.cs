using Cuuxi.SurePath.DAL.Models.DTO;
using Cuuxi.SurePath.Portal.BLL.Models;
using System.Net.Http.Json;

namespace Cuuxi.SurePath.Portal.BLL.Services
{
    public class UserService : BaseService
    {
        private readonly HttpClient _httpClient;

        public UserService(Connector connector) : base(connector)
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(connector.settings.ApiUrl) };
        }

        public Task<LoginResult?> LoginAsync(string provider, string username, string password) =>
            _httpClient.PostAsJsonAsync("api/auth/login", new { provider, username, password })
                .ContinueWith(t => t.Result.Content.ReadFromJsonAsync<LoginResult>()).Unwrap();

        public Task<UserDto?> GetAsync(int id) =>
            _httpClient.GetFromJsonAsync<UserDto>($"api/users/{id}");

        public async Task<UserDto?> UpdateAsync(int id, string? firstName = null, string? lastName = null, string? countryCode = null)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/users/{id}", new { firstName, lastName, countryCode });
            return await response.Content.ReadFromJsonAsync<UserDto>();
        }

        public Task<List<CountryDto>> GetCountriesAsync() =>
            _httpClient.GetFromJsonAsync<List<CountryDto>>("api/countries")!;

        public override void Dispose()
        {
            _httpClient.Dispose();
            base.Dispose();
        }
    }
}
