using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BDSA2018.Assignment08.Entities
{
    public class Track
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public double LengthInMeters { get; set; }

        public long? BestLapInTicks { get; set; }

        public int MaxCars { get; set; }

        public ICollection<Race> Races { get; set; }

        public Track()
        {
            Races = new HashSet<Race>();
        }
    }
}