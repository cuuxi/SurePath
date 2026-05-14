using Cuuxi.SurePath.Backend.BLL;
using Cuuxi.SurePath.Backend.Services;
using Cuuxi.SurePath.DAL.Models.DTO;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cuuxi.SurePath.Backend.Pages.Users;

public class DetailsModel : PageModel
{
    private readonly Connector _connector;
    private readonly TranslationService _translations;
    public new UserDto? User { get; private set; }
    public List<UserLoginLogDto> LoginLogs { get; private set; } = new();

    public DetailsModel(Connector connector, TranslationService translations)
    {
        _connector = connector;
        _translations = translations;
    }

    public async Task OnGetAsync(int id)
    {
        await _translations.EnsureLoadedAsync();
        User = await _connector.Users.GetAsync(id);
        if (User is not null)
            LoginLogs = await _connector.Users.GetLoginLogsAsync(id);
    }
}
