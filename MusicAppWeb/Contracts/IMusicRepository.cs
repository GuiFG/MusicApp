using System.Collections.Generic;
using System.Threading.Tasks;
using MusicAppWeb.Model;

namespace MusicAppWeb.Contracts
{
    public interface IMusicRepository 
    {
        Task<List<Music>> GetAll();
        Task<Music> Upload(Music music);
    }
}