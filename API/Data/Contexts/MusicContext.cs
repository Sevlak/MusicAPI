using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class MusicContext: DbContext
    {
        protected internal DbSet<Music> Musics { get; set; }
        
        public MusicContext(DbContextOptions<MusicContext> opt): base(opt){}
    }
}