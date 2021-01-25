using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BDSA2018.Assignment08.Entities
{
    public class Car
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Driver { get; set; }

        public byte[] Image { get; set; }

        public ICollection<CarInRace> CarsInRace { get; set; }

        public Car()
        {
            CarsInRace = new HashSet<CarInRace>();
        }
    }
}