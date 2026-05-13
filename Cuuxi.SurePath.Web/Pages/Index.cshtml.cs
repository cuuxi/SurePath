using Cuuxi.SurePath.Web.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cuuxi.SurePath.Web.Pages;

public class IndexModel : PageModel
{
    private readonly TranslationService _translations;

    public string Lang => _translations.Lang;

    public IndexModel(TranslationService translations) => _translations = translations;

    public async Task OnGetAsync() => await _translations.EnsureLoadedAsync();
}
