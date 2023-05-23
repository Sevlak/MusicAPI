using System.ComponentModel.DataAnnotations;

namespace API.Models.DTO
{
    public class MusicDto: IDtoConvertible<Music>
    {
        [Required] public string Name { get; set; }
        [Required] public TimeSpan Duration { get; set; }
        [Required] public AlbumDto Album { get; set; }

        public Music Map()
        {
            return new Music()
            {
                Album = this.Album.Map(),
                Name = this.Name,
                Duration = this.Duration
            };
        }
    }
}