using API.Models;

namespace API.Data
{
    public interface IMusicRepository
    {
        public Task<Music> CreateMusic(Music m);
        public Task<Music> GetMusic(int Id);
        public Task<IAsyncEnumerable<Music>> GetAllMusics();
        public Task<Music> UpdateMusic(Music m);
        public Task<Music> DeleteMusic(Music m);
    }
}