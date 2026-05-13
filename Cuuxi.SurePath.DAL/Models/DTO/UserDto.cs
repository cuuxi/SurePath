namespace Cuuxi.SurePath.DAL.Models.DTO;

public class UserDto
{
    public int Id { get; init; }
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public bool IsActive { get; init; }
    public string CountryCode { get; init; } = string.Empty;
}
