using System.Security.Claims;
using Cuuxi.SurePath.Portal.BLL;
using Cuuxi.SurePath.Portal.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cuuxi.SurePath.Portal.Pages;

public class LoginModel : PageModel
{
    private readonly Connector _connector;
    private readonly TranslationService _translations;

    [BindProperty] public string Username { get; set; } = string.Empty;
    [BindProperty] public string Password { get; set; } = string.Empty;
    public string? ErrorMessage { get; private set; }

    public LoginModel(Connector connector, TranslationService translations)
    {
        _connector = connector;
        _translations = translations;
    }

    public async Task<IActionResult> OnGetAsync()
    {
        await _translations.EnsureLoadedAsync();
        return User.Identity?.IsAuthenticated == true ? RedirectToPage("/Profile") : Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await _translations.EnsureLoadedAsync();

        var result = await _connector.Users.LoginAsync("Basic", Username, Password);

        if (result is null || !result.Success)
        {
            ErrorMessage = result?.ErrorType == "inactive"
                ? _translations.T("portal.login.error.inactive", "Din konto er ikke aktiv.")
                : _translations.T("portal.login.error.invalid", "Ukendt brugernavn eller forkert adgangskode.");
            return Page();
        }

        var claims = new List<Claim>
        {
            new("userId", result.UserId!.Value.ToString()),
            new("firstName", result.FirstName!),
            new("lastName", result.LastName!)
        };
        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

        return RedirectToPage("/Profile");
    }
}
