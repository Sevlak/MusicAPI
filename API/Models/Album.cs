using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Album
    {
        public int Id { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int TotalMusics { get; set; }
        [Required] public string Name { get; set; }
        [Required] public Artist Artist { get; set; }
    }
}