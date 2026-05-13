namespace Cuuxi.SurePath.DAL.Entities;

public class UserLoginLog
{
    public int Id { get; set; }
    public int? UserId { get; set; }
    public string Provider { get; set; } = string.Empty;
    public string ProviderKey { get; set; } = string.Empty;
    public bool Success { get; set; }
    public DateTimeOffset LoggedAt { get; set; }

    public User? User { get; set; }
}
