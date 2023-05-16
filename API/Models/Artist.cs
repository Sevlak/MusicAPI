using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Artist
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Album> Albums { get; set; }
    }
}