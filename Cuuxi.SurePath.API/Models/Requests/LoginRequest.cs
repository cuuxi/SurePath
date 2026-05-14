namespace Cuuxi.SurePath.API.Models.Requests
{
    public record LoginRequest(string Provider, string Username, string Password);
}
