using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BDSA2018.Assignment04.Entities
{
    public class Race
    {
        public int Id { get; set; }

        [Required]
        public Track Track { get; set; }

        [Required]
        public int NumberOfLaps { get; set; }

    }
}
