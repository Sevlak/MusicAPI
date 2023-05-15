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

        public async Task<Music> GetMusic(int Id)
        {
            var m = await _context.Musics.FindAsync(Id);

            return m;
        }

        public async Task<IAsyncEnumerable<Music>> GetAllMusics()
        {
            return _context.Musics.AsAsyncEnumerable();
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