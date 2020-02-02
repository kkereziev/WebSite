using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectShop.Models.Discounts;
using ProjectShop.Models.New_Collection;

namespace ProjectShop.Models.Shoes.Boots
{
    public class Boots
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public ICollection<BootsModel> Models { get; set; }
    }
}
