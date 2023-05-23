using System.ComponentModel.DataAnnotations;
using API.Models.DTO;

namespace API.Models
{
    public class Album: IDtoConvertible<AlbumDto>
    {
        public int Id { get; set; }
        public int TotalMusics { get; set; }
        
        //this property should also use the DataType.Date annotation so that the ReleaseDate isn't extremely specific
        [DataType(DataType.Date)] public DateTime ReleaseDate { get; set; } 
        public string Name { get; set; }
        public Artist Artist { get; set; }

        public AlbumDto Map()
        {
            return new AlbumDto()
            {
                Artist = this.Artist.Map(),
                Name = this.Name,
                ReleaseDate = this.ReleaseDate,
                TotalMusics = this.TotalMusics
            };
        }
    }
}