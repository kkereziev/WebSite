using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectShop.Models.Discounts;
using ProjectShop.Models.New_Collection;

namespace ProjectShop.Models.Shoes.HighHeeledShoes
{
    public class HighHeeledShoes
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public ICollection<HighHeeledShoesColors> Colors { get; set; }
        public ICollection<HighHeeledShoesSize> Size { get; set; }
        public Guid NewCollectionId { get; set; }
        public NewCollection NewCollection { get; set; }
        public Guid DiscountsId { get; set; }
        public Discount Discounts { get; set; }
    }
}
