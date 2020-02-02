using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectShop.Models.Discounts;
using ProjectShop.Models.New_Collection;

namespace ProjectShop.Models.Shoes.CasualShoes
{
    public class CasualShoes
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public ICollection<ColorOfCasualShoes> Colors { get; set; }
        public ICollection<SizeOfCasualShoes> Size { get; set; }
        public Guid NewCollectionId { get; set; }
        public NewCollection NewCollection { get; set; }
        public Guid DiscountsId { get; set; }
        public Discount Discounts { get; set; }
    }
}
