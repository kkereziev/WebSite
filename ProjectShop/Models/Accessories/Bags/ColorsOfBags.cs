using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectShop.Models.Accessories.Bags
{
    public class ColorsOfBags
    {
        public Guid Id { get; set; }
        public string ColorOfBag { get; set; }
        public Guid BagId { get; set; }
        public Bags Bag { get; set; }
    }
}
