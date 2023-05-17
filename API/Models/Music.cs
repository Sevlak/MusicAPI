using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Music
    {
        public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public TimeSpan Duration { get; set; }
        [Required] public Album Album { get; set; }
    }
}