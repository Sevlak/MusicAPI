using System.ComponentModel.DataAnnotations;

namespace API.Models.DTO
{
    public class ArtistDto: IDtoConvertible<Artist>
    {
        [Required] public string Name { get; set; }

        public Artist Map()
        {
            return new Artist()
            {
                Name = this.Name
            };
        }
    }
}