using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MusicAppWeb.Pages.Home
{
    [Authorize]
    public class IndexHomeModel : PageModel
    {

        public IndexHomeModel()
        {
        }

        public IActionResult OnGet()
        {
            TempData["messageSuccess"] = "ola que tal";
            return Page();
        }
    }
}
