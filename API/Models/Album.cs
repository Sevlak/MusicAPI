using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Album
    {
        public int Id { get; set; }
        public int TotalMusics { get; set; }
        [DataType(DataType.Date)]public DateTime ReleaseDate { get; set; }
        [Required] public string Name { get; set; }
        [Required] public Artist Artist { get; set; }
    }
}