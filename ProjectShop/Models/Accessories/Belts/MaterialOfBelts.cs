using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectShop.Models.Accessories.Belts
{
    public class MaterialOfBelts
    {
        public Guid Id { get; set; }
        public string MaterialOfBelt { get; set; }
        public Guid BeltId { get; set; }
        public Belts Belt { get; set; }
    }
}
