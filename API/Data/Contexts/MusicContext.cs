using API.Data.Configurations;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Contexts
{
    public class MusicContext: DbContext
    {
        protected internal DbSet<Music> Musics { get; set; }
        protected internal DbSet<Artist> Artists { get; set; }
        protected internal DbSet<Album> Albums { get; set; }

        public MusicContext(DbContextOptions<MusicContext> opt): base(opt){}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new MusicConfiguration());
        }
    }
}