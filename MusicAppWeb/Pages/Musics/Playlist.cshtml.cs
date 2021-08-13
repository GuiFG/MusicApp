using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicAppWeb.Model;
using MusicAppWeb.Contracts;

namespace MusicAppWeb.Pages.Musics
{
    public class PlaylistModel : PageModel
    {
        private readonly IMusicRepository _repoMusics;
        [BindProperty]
        public List<Music> Musics { get; set; }
        public PlaylistModel(IMusicRepository repoMusics)
        {
            _repoMusics = repoMusics;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                Musics = await _repoMusics.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Page();
        }

        public IActionResult OnPost() {
            TempData["messageSuccess"] = "Playlist created!";

            return RedirectToPage("/Musics/Playlist");
        }
    }
}
