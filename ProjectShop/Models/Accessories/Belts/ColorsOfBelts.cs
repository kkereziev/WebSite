using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectShop.Models.Accessories.Belts
{
    public class ColorsOfBelts
    {
        public Guid Id { get; set; }
        public string ColorOfBelt { get; set; }
        public Guid BeltId { get; set; }
        public Belts Belt { get; set; }
    }
}
