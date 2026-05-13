namespace Cuuxi.SurePath.DAL.Models.DTO;

public class TranslationDto
{
    public int Id { get; init; }
    public string LanguageCode { get; init; } = string.Empty;
    public string Key { get; init; } = string.Empty;
    public string Value { get; init; } = string.Empty;
}
