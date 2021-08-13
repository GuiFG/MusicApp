using System.Collections.Generic;
using System.Threading.Tasks;
using MusicAppApi.Model;

namespace MusicAppApi.Contracts
{
    public interface IMusicRepository 
    {
        Task<Music> Save(Music music);
        Task<List<Music>> GetAll();
    }
}