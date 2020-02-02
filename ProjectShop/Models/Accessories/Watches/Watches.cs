using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectShop.Models.Discounts;
using ProjectShop.Models.New_Collection;

namespace ProjectShop.Models.Accessories.Watches
{
    public class Watches
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public ICollection<StylesOfWatches> Styles { get; set; }
        public Guid NewCollectionId { get; set; }
        public NewCollection NewCollection { get; set; }
        public Guid DiscountsId { get; set; }
        public Discount Discounts { get; set; }
    }
}
