using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BDSA2018.Assignment08.Shared
{
    public class CarUpdateDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Driver { get; set; }

        public byte[] Image { get; set; }
    }
}
