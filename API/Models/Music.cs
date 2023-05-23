using API.Models.DTO;

namespace API.Models
{
    public class Music: IDtoConvertible<MusicDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public Album Album { get; set; }

        public MusicDto Map()
        {
            return new MusicDto()
            {
                Album = this.Album.Map(),
                Duration = this.Duration,
                Name = this.Name
            };
        }
    }
}