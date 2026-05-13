using Cuuxi.SurePath.DAL;
using Cuuxi.SurePath.DAL.Models.DTO;
using Cuuxi.SurePath.Portal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cuuxi.SurePath.Portal.Pages;

[Authorize]
public class ProfileModel : PageModel
{
    private readonly Connector _connector;
    private readonly TranslationService _translations;

    [BindProperty] public string FirstName { get; set; } = string.Empty;
    [BindProperty] public string LastName { get; set; } = string.Empty;
    [BindProperty] public string CountryCode { get; set; } = string.Empty;
    public List<CountryDto> Countries { get; private set; } = new();

    public ProfileModel(Connector connector, TranslationService translations)
    {
        _connector = connector;
        _translations = translations;
    }

    private int UserId => int.Parse(User.FindFirst("userId")!.Value);

    public async Task OnGetAsync()
    {
        await _translations.EnsureLoadedAsync();
        var user = await _connector.Users.GetAsync(UserId);
        if (user is not null)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            CountryCode = user.CountryCode;
        }
        Countries = await _connector.Countries.GetAllAsync();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await _translations.EnsureLoadedAsync();
        await _connector.Users.UpdateAsync(UserId, firstName: FirstName, lastName: LastName, countryCode: CountryCode);
        Countries = await _connector.Countries.GetAllAsync();
        TempData["Success"] = _translations.T("portal.profile.saved", "Dine oplysninger er gemt.");
        return RedirectToPage();
    }
}
