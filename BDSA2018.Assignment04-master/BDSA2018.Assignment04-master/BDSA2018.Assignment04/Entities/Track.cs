using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BDSA2018.Assignment04.Entities
{
    public class Track
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public int? Length { get; set; }

        [Required]
        public long? BestLapTime { get; set; }

        [Required]
        public int? MaxCars { get; set; }


    }
}
