namespace Cuuxi.SurePath.DAL.Entities;

public class UserLogin
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Provider { get; set; } = string.Empty;
    public string ProviderKey { get; set; } = string.Empty;
    public string? ProviderSecret { get; set; }

    public User User { get; set; } = null!;
}
