using System.Security.Claims;
using Cuuxi.SurePath.DAL;
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

        var login = await _connector.UserLogins.FindAsync("Basic", Username);

        if (login is null)
        {
            await _connector.UserLoginLogs.CreateAsync("Basic", Username, success: false);
            ErrorMessage = _translations.T("portal.login.error.invalid", "Ukendt brugernavn eller forkert adgangskode.");
            return Page();
        }

        var secret = await _connector.UserLogins.GetSecretAsync("Basic", Username);
        var valid = secret is not null && BCrypt.Net.BCrypt.Verify(Password, secret);

        var user = valid ? await _connector.Users.GetAsync(login.UserId) : null;
        if (!valid || user is null || !user.IsActive)
        {
            await _connector.UserLoginLogs.CreateAsync("Basic", Username, success: false, userId: login.UserId);
            ErrorMessage = valid && user is not null
                ? _translations.T("portal.login.error.inactive", "Din konto er ikke aktiv.")
                : _translations.T("portal.login.error.invalid", "Ukendt brugernavn eller forkert adgangskode.");
            return Page();
        }

        await _connector.UserLoginLogs.CreateAsync("Basic", Username, success: true, userId: user.Id);

        var claims = new List<Claim>
        {
            new("userId", user.Id.ToString()),
            new("firstName", user.FirstName),
            new("lastName", user.LastName)
        };
        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

        return RedirectToPage("/Profile");
    }
}
