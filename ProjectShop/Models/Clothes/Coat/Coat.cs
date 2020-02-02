using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectShop.Models.Discounts;
using ProjectShop.Models.New_Collection;

namespace ProjectShop.Models.Clothes.Coat
{
    public class Coat
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public ICollection<CoatModel> Models { get; set; }
    }
}
