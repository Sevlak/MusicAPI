using API.Data.Contexts;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class MusicRepository: IMusicRepository
    {
        private readonly MusicContext _context;

        public MusicRepository(MusicContext ctx)
        {
            _context = ctx;
        }

        public async Task<Music> CreateMusic(Music m)
        {
            await _context.Musics.AddAsync(m);
            await _context.SaveChangesAsync();

            return m;
        }

        public async Task<Music> GetMusic(int id)
        {
            var m = await _context.Musics
                .Include(music => music.Album)
                .Include(music => music.Album.Artist)
                .Where(music => music.Id == id)
                .SingleOrDefaultAsync();

            return m;
        }

        public async Task<IAsyncEnumerable<Music>> GetAllMusics()
        {
            //We prevent the context from  unnecessarily tracking the data because it is intended for read-only use.
            //https://www.learnentityframeworkcore.com/walkthroughs/aspnetcore-application
            return _context.Musics
                .AsNoTracking()
                .Include(music => music.Album)
                .Include(music => music.Album.Artist)
                .AsAsyncEnumerable();
        }

        public async Task<Music> UpdateMusic(Music m)
        {
            _context.Musics.Update(m);
            await _context.SaveChangesAsync();

            return m;
        }

        public async Task<Music> DeleteMusic(Music m)
        {
            _context.Musics.Remove(m);
            await _context.SaveChangesAsync();

            return m;
        }
    }
}