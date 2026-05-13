using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cuuxi.SurePath.Backend.Pages;

public class IndexModel : PageModel
{
    public IActionResult OnGet() => RedirectToPage("/Users/Index");
}
