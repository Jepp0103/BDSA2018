using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BDSA2018.Assignment04.Entities
{
    public class CarInRace
    {
        [Key]
        public int CarId { get; set; }

        [Key]
        public int RaceId { get; set; }

        [Required]
        public Race Race { get; set; }

        [Required]
        public int StartPosition { get; set; }

        [Required]
        public int EndPosition { get; set; }

        [Required]
        public long? BestLap { get; set; }

        [Required]
        public long? TotalRaceTime { get; set; }
    }
}
