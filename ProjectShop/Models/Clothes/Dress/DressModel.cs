using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectShop.Models.Clothes.Dress
{
    public class DressModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<DressColor> Colors { get; set; }
        public ICollection<DressSize> Size { get; set; }
        public Guid DressId { get; set; }
        public Dress Dress { get; set; }
    }
}
