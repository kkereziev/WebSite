using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectShop.Models.Accessories.Jewelry
{
    public class CategoryOfJewelry
    {
        public Guid Id { get; set; }
        public string CategoryOfJewel { get; set; }
        public Guid JewelryId { get; set; }
        public Jewelry Jewelry { get; set; }
    }
}
