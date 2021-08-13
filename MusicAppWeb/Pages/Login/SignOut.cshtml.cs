using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;

namespace MusicAppWeb.Pages
{
    public class SignOutModel : PageModel
    {
        public SignOutModel()
        {
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await HttpContext.SignOutAsync("token");

            return RedirectToPage("/Index");
        }
    }
}
