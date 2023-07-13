using Aviation.BL.Validators;
using System.ComponentModel.DataAnnotations;

namespace Aviation.BL.Dto
{
    public class AirCraftCreate
    {
        public int Id { get; set; }

        [MaxLength(128)]
        public string Make { get; set; }

        [MaxLength(128)]
        public string Model { get; set; }

        [MaxLength(8)]
        [RegexValidation(@"^[A-Za-z]{1,2}-[A-Za-z]{1,5}$")]
        public string Registration { get; set; }

        [MaxLength(255)]
        public string Location { get; set; }

        [PastDate]
        public DateTime Date { get; set; }

        public string ImageUrl { get; set; }
    }
}
