using Cuuxi.SurePath.Backend.BLL;

namespace Cuuxi.SurePath.Backend.Services;

public class TranslationService
{
    private readonly Connector _connector;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private Dictionary<string, string>? _dict;

    public string Lang { get; private set; } = "da";

    public TranslationService(Connector connector, IHttpContextAccessor httpContextAccessor)
    {
        _connector = connector;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task EnsureLoadedAsync()
    {
        if (_dict != null) return;
        var ctx = _httpContextAccessor.HttpContext!;
        var queryLang = ctx.Request.Query["lang"].FirstOrDefault();
        Lang = queryLang ?? ctx.Request.Cookies["lang"] ?? "da";
        if (queryLang != null)
            ctx.Response.Cookies.Append("lang", Lang, new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) });
        _dict = await _connector.Translations.GetDictionaryAsync(Lang);
    }

    public string T(string key, string fallback) =>
        _dict?.TryGetValue(key, out var v) == true ? v : fallback;
}
