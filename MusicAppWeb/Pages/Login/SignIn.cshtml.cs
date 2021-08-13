using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
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
            Console.WriteLine("oi");

            if (userAuthenticated != null)
            {
                Console.WriteLine("autenticado");
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, userAuthenticated.Username),
                    new Claim(ClaimTypes.Role, userAuthenticated.Role),
                    new Claim(ClaimTypes.Hash, userAuthenticated.Token)
                };

                var identity = new ClaimsIdentity(claims, Auth.TokenName);
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(Auth.TokenName, claimsPrincipal);

                return RedirectToPage("/Home/Index");
            }

            return Page();
        }
    }
}
