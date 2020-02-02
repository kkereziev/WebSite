using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectShop.Models.Clothes.Blouse
{
    public class BlouseSize
    {
        public Guid Id { get; set; }
        [Required]
        public int SizeOfBlouse { get; set; }
        public Guid ModelId { get; set; }
        public BlouseModel Model { get; set; }
    }
}
