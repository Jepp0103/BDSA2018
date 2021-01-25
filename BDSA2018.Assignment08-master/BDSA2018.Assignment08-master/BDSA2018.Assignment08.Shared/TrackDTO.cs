﻿using System;
using System.ComponentModel.DataAnnotations;

namespace BDSA2018.Assignment08.Shared
{
    public class TrackDTO
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public double LengthInMeters { get; set; }

        public TimeSpan? BestLap { get; set; }

        public int MaxCars { get; set; }

        public int NumberOfRaces { get; set; }
    }
}
