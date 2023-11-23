using System.ComponentModel.DataAnnotations;

namespace MagicVilla_VillaAPI.Dto
{
    public class VillaDTO
    {

        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public int Occupancy { get; set; }
        public int SqFt { get; set; }
        public string Details { get; set; }
        public string ImageUrl { get; set; }
        public string Amenity { get; set; }
        public Double Rate { get; set; } 
    }
}
