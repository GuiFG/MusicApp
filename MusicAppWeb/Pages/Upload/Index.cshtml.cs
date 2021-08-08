using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MusicAppWeb.Pages.Upload
{
    public class IndexUploadModel : PageModel
    {

        public IndexUploadModel()
        {
        }

        public IActionResult OnGet()
        {
            return Page();
        }
    }
}
