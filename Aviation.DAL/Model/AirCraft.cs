using System.ComponentModel.DataAnnotations;

namespace Aviation.DAL.Model
{
    public class AirCraft
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(128)]
        public string Make { get; set; }

        [MaxLength(128)]
        public string Model { get; set; }

        [MaxLength(8)]
        public string Registration { get; set; }

        [MaxLength(255)]
        public string Location { get; set; }

        public DateTime Date { get; set; }

        public string? ImageUrl { get; set; }
    }
}
