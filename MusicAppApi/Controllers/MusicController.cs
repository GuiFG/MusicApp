using System;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicAppApi.Services;
using MusicAppApi.Model;
using MusicAppApi.Contracts;
using Microsoft.AspNetCore.Authorization;


namespace MusicAppApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MusicsController : ControllerBase
    {
        private readonly IMusicRepository _musicRepository;
        public MusicsController(IMusicRepository musicRepository)
        {
            _musicRepository = musicRepository;
        }

        [HttpGet]
        public async Task<dynamic> GetAll()
        {
            try 
            {
                var musics = await _musicRepository.GetAll();

                return Ok(new { data = musics });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Problem();
            }
        }

        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> Upload(Music music)
        {
            try 
            {   
                var m = await _musicRepository.Save(music);
                if (m == null)
                    return Problem();
                    
                return Ok(m);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return Problem();
            }
        }
    }
}
