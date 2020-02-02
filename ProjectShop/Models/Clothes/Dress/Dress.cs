using System;
using System.Collections.Generic;
using ProjectShop.Models.Discounts;
using ProjectShop.Models.New_Collection;

namespace ProjectShop.Models.Clothes.Dress
{
    public class Dress 
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public ICollection<DressModel> Models { get; set; }
    }
}
