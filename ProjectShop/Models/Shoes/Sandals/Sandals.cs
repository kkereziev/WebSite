using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectShop.Models.Discounts;
using ProjectShop.Models.New_Collection;

namespace ProjectShop.Models.Shoes.Sandals
{
    public class Sandals
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public ICollection<ColorOfSandals> Colors { get; set; }
        public ICollection<SizeOfSandals> Size { get; set; }
        public Guid NewCollectionId { get; set; }
        public NewCollection NewCollection { get; set; }
        public Guid DiscountsId { get; set; }
        public Discount Discounts { get; set; }
    }
}
