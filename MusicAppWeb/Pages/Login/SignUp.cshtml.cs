using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicAppWeb.Contracts;
using MusicAppWeb.Model;

namespace MusicAppWeb.Pages
{
    public class SignUpModel : PageModel
    {
        private readonly IUserRepository _repoUser;
        [BindProperty]
        public User user { get; set; }

        public SignUpModel(IUserRepository repoUser)
        {
            _repoUser = repoUser;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            User userCreated = await _repoUser.SignUp(user);
            
            if (userCreated != null) 
                return RedirectToPage("/Home/Index");
            
            return Page();
        }
    }
}
