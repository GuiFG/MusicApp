using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using MusicAppApi.Services;
using MusicAppApi.Model;
using MusicAppApi.Contracts;

namespace MusicAppApi.Repository 
{
    public class MusicRepository : IMusicRepository 
    {
        private readonly MusicAppContext _context;
        public MusicRepository(MusicAppContext context)
        {
            _context = context;
        }
        public async Task<Music> Save(Music music)
        {
            try 
            {
                music.CreatedDate = DateTime.Today;
                
                await _context.AddAsync(music);

                await _context.SaveChangesAsync();

                return music;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Music>> GetAll()
        {
            try 
            {
                var musics = await Task.Run(() => 
                    _context.Musics.Select(m => 
                        new Music {
                            Id = m.Id,
                            Name = m.Name,
                            Lyrics = m.Lyrics,
                            Time = m.Time,
                            Played = m.Played,
                            Likes = m.Likes,
                            CreatedDate = m.CreatedDate.Date
                        }
                    ).ToList()
                );

                return musics;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}