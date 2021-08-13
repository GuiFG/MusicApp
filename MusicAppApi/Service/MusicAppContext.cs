using Microsoft.EntityFrameworkCore;
using MusicAppApi.Model;

namespace MusicAppApi.Services 
{
    public class MusicAppContext : DbContext 
    {
        public MusicAppContext(DbContextOptions<MusicAppContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Music> Musics { get; set; }
    }
}