using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectShop.Models.Clothes.Coat
{
    public class CoatModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<CoatColor> Colors { get; set; }
        public ICollection<CoatSize> Size { get; set; }
        public Guid CoatId { get; set; }
        public Coat Coat { get; set; }
    }
}
