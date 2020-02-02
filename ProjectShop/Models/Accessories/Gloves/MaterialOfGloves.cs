using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectShop.Models.Accessories.Gloves
{
    public class MaterialOfGloves
    {
        public Guid Id { get; set; }
        public string MaterialsOfGloves { get; set; }
        public Guid GlovesId { get; set; }
        public Gloves Gloves { get; set; }
    }
}
