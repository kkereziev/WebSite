using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectShop.Models.Discounts;
using ProjectShop.Models.New_Collection;

namespace ProjectShop.Models.Clothes.Shirt
{
    public class Shirt
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public ICollection<ShirtColor> Colors { get; set; }
        public ICollection<ShirtSize> Size { get; set; }
        public Guid NewCollectionId { get; set; }
        public NewCollection NewCollections { get; set; }
        public Guid DiscountsId { get; set; }
        public Discount Discounts { get; set; }
    }
}
