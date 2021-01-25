using System.ComponentModel.DataAnnotations;

namespace BDSA2018.Assignment08.Shared
{
    public class CarCreateDTO
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Driver { get; set; }

        public byte[] Image { get; set; }
    }
}
