using System.ComponentModel.DataAnnotations;

namespace API.Models.DTO
{
    public class AlbumDto: IDtoConvertible<Album>
    {
        public int TotalMusics { get; set; }
        [DataType(DataType.Date)] public DateTime ReleaseDate { get; set; }
        [Required] public string Name { get; set; }
        [Required] public ArtistDto Artist { get; set; }

        public Album Map()
        {
            return new Album()
            {
                Artist = this.Artist.Map(),
                Name = this.Name,
                ReleaseDate = this.ReleaseDate,
                TotalMusics = this.TotalMusics
            };
        }
    }
}