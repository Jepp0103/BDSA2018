using System.ComponentModel.DataAnnotations;

namespace BDSA2018.Assignment08.Shared
{
    public class TrackCreateDTO
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public double LengthInMeters { get; set; }

        public int MaxCars { get; set; }
    }
}
