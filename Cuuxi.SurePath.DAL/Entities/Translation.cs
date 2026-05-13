namespace Cuuxi.SurePath.DAL.Entities;

public class Translation
{
    public int Id { get; set; }
    public string LanguageCode { get; set; } = string.Empty;
    public string Key { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;

    public Language Language { get; set; } = null!;
    public TranslationKey TranslationKey { get; set; } = null!;
}
