using Cuuxi.SurePath.Backend.Services;
using Cuuxi.SurePath.DAL;
using Cuuxi.SurePath.DAL.Models.DTO;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cuuxi.SurePath.Backend.Pages.Users;

public class IndexModel : PageModel
{
    private readonly Connector _connector;
    private readonly TranslationService _translations;
    public List<UserDto> Users { get; private set; } = new();

    public IndexModel(Connector connector, TranslationService translations)
    {
        _connector = connector;
        _translations = translations;
    }

    public async Task OnGetAsync()
    {
        await _translations.EnsureLoadedAsync();
        Users = await _connector.Users.GetAllAsync();
    }
}
