using API.Models.DTO;

namespace API.Models
{
    public class Artist: IDtoConvertible<ArtistDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ArtistDto Map()
        {
            return new ArtistDto()
            {
                Name = this.Name
            };
        }
    }
}