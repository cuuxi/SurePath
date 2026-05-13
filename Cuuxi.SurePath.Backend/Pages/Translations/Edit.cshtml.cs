using Cuuxi.SurePath.Backend.Services;
using Cuuxi.SurePath.DAL;
using Cuuxi.SurePath.DAL.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cuuxi.SurePath.Backend.Pages.Translations;

public class EditModel : PageModel
{
    private readonly Connector _connector;
    private readonly TranslationService _translations;

    public string Key { get; private set; } = string.Empty;
    public string? Description { get; private set; }
    public List<LanguageDto> Languages { get; private set; } = new();
    public List<TranslationDto> Existing { get; private set; } = new();

    [BindProperty] public string? BoundKey { get; set; }
    [BindProperty] public List<TranslationValue> Values { get; set; } = new();

    public EditModel(Connector connector, TranslationService translations)
    {
        _connector = connector;
        _translations = translations;
    }

    public async Task OnGetAsync(string key)
    {
        await _translations.EnsureLoadedAsync();
        Key = key;
        var keyDto = await _connector.TranslationKeys.GetAsync(key);
        Description = keyDto?.Description;
        Languages = await _connector.Languages.GetAllActiveAsync();
        Existing = await _connector.Translations.GetAllForLanguageAsync(key);
    }

    public async Task<IActionResult> OnPostAsync(string key)
    {
        await _translations.EnsureLoadedAsync();
        foreach (var v in Values)
        {
            if (string.IsNullOrEmpty(v.LanguageCode)) continue;
            var existing = await _connector.Translations.GetAsync(v.LanguageCode, key);
            if (existing is null)
                await _connector.Translations.CreateAsync(v.LanguageCode, key, v.Value ?? string.Empty);
            else
                await _connector.Translations.UpdateAsync(existing.Id, v.Value ?? string.Empty);
        }

        TempData["Success"] = _translations.T("backend.translations.saved", "Oversættelser gemt.");
        return RedirectToPage(new { key });
    }

    public string GetValue(string languageCode) =>
        Existing.FirstOrDefault(e => e.LanguageCode == languageCode)?.Value ?? string.Empty;

    public class TranslationValue
    {
        public string LanguageCode { get; set; } = string.Empty;
        public string? Value { get; set; }
    }
}
