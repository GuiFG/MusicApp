using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MusicAppWeb.Pages.Library
{
    public class PlaylistsModel : PageModel
    {

        public PlaylistsModel()
        {
        }

        public IActionResult OnGet()
        {
            return Page();
        }
    }
}
