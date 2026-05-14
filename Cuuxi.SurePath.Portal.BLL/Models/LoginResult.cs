namespace Cuuxi.SurePath.Portal.BLL.Models
{
    public record LoginResult(bool Success, int? UserId, string? FirstName, string? LastName, string? ErrorType);
}
