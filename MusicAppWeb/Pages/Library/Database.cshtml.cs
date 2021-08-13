using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicAppWeb.Contracts;
using MusicAppWeb.Model;


namespace MusicAppWeb.Pages.Library
{
    public class DatabaseModel : PageModel
    {
        private readonly IMusicRepository _repoMusic;
        public List<Music> musics;
        public DatabaseModel(IMusicRepository musicRepository)
        {
            _repoMusic = musicRepository;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                musics = await _repoMusic.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Page();
        }
    }
}
