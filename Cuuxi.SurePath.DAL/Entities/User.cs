namespace Cuuxi.SurePath.DAL.Entities;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public string CountryCode { get; set; } = string.Empty;

    public Country Country { get; set; } = null!;
}
