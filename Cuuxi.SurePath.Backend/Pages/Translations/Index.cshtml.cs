using Cuuxi.SurePath.Backend.BLL;
using Cuuxi.SurePath.Backend.Services;
using Cuuxi.SurePath.DAL.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cuuxi.SurePath.Backend.Pages.Translations;

public class IndexModel : PageModel
{
    private readonly Connector _connector;
    private readonly TranslationService _translations;
    public List<TranslationKeyDto> Keys { get; private set; } = new();

    [BindProperty] public string NewKey { get; set; } = string.Empty;
    [BindProperty] public string? NewDescription { get; set; }

    public IndexModel(Connector connector, TranslationService translations)
    {
        _connector = connector;
        _translations = translations;
    }

    public async Task OnGetAsync()
    {
        await _translations.EnsureLoadedAsync();
        Keys = await _connector.Translations.GetAllKeysAsync();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await _translations.EnsureLoadedAsync();
        if (!string.IsNullOrWhiteSpace(NewKey))
            await _connector.Translations.CreateKeyAsync(NewKey.Trim(), NewDescription?.Trim());

        return RedirectToPage();
    }
}
