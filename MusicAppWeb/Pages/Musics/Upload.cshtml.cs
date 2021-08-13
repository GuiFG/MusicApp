using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using MusicAppWeb.Contracts;
using MusicAppWeb.Model;

namespace MusicAppWeb.Pages.Upload
{
    public class MusicUploadModel : PageModel
    {
        private readonly IMusicRepository _repoMusic;
        [BindProperty]
        public Music Music { get; set; }
        [BindProperty]
        public IFormFile Upload { get; set; }
        public MusicUploadModel(IMusicRepository repoMusic)
        {
            _repoMusic = repoMusic;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Music music) 
        {
            try
            {  
                music.File = GetFileString(Upload);
                
                var musicUploaded = await _repoMusic.Upload(music);

                if (musicUploaded != null)
                    TempData["messageSuccess"] = "Upload completed.";
                else 
                    TempData["messageSuccess"] = "Error in upload music.";

                return Page();
            }
            catch (Exception ex)
            {
                TempData["messageError"] = $"Error while uploading the music. [{ex.Message}]";
                return Page();
            }
        }

        private string GetFileString(IFormFile formFile) 
        {
            try
            {
                if (formFile == null) return String.Empty;

                var ms = new MemoryStream();
                formFile.CopyTo(ms);
                var fileBytes = ms.ToArray();

                return Convert.ToBase64String(fileBytes);
            } 
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
