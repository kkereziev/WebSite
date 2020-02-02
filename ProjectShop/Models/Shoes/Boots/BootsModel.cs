using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectShop.Models.Shoes.Boots
{
    public class BootsModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<ColorOfBoots> Colors { get; set; }
        public ICollection<SizeOfBoots> Size { get; set; }
        public Guid BootsId { get; set; }
        public Boots Boots { get; set; }
    }
}
