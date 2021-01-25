using System;
using System.ComponentModel.DataAnnotations;

namespace BDSA2018.Assignment04.Entities
{
    public class Car
    {
        // TODO: Use class for SlotCarContext...
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string DriverName { get; set; }

        public override bool Equals(object obj)
        {
            var OtherCar = obj as Car;

            bool isEqual =
                this.Id == OtherCar.Id &&
                this.Name.Equals(OtherCar.Name) &&
                this.DriverName.Equals(OtherCar.DriverName);

            return isEqual;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, DriverName);
        }

    }
}