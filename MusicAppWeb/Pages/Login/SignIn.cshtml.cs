using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicAppWeb.Contracts;
using MusicAppWeb.Model;

namespace MusicAppWeb.Pages
{
    public class SignInModel : PageModel
    {
        private readonly IUserRepository _repoUser;
        [BindProperty]
        public User user { get; set; }

        public SignInModel(IUserRepository repoUser)
        {
            _repoUser = repoUser;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var userAuthenticated = await _repoUser.Authenticate(user);

            if (userAuthenticated != null)
                return RedirectToPage("/Home/Index");

            return Page();
        }
    }
}
