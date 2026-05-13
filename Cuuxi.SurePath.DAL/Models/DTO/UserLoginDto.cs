namespace Cuuxi.SurePath.DAL.Models.DTO;

public class UserLoginDto
{
    public int Id { get; init; }
    public int UserId { get; init; }
    public string Provider { get; init; } = string.Empty;
    public string ProviderKey { get; init; } = string.Empty;
}
