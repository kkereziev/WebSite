using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectShop.Models.Accessories.Bags;
using ProjectShop.Models.Accessories.Belts;
using ProjectShop.Models.Accessories.Gloves;
using ProjectShop.Models.Accessories.Jewelry;
using ProjectShop.Models.Accessories.Watches;
using ProjectShop.Models.Clothes.Blouse;
using ProjectShop.Models.Clothes.Coat;
using ProjectShop.Models.Clothes.Dress;
using ProjectShop.Models.Clothes.Panths;
using ProjectShop.Models.Clothes.Shirt;
using ProjectShop.Models.Shoes.Boots;
using ProjectShop.Models.Shoes.CasualShoes;
using ProjectShop.Models.Shoes.HighHeeledShoes;
using ProjectShop.Models.Shoes.Sandals;
using ProjectShop.Models.Shoes.Slippers;
using ProjectShop.Models.Shoes.SportShoes;

namespace ProjectShop.Models.New_Collection
{
    public class NewCollection
    {
        public Guid Id { get; set; }
        public ICollection<Blouse> Blouses { get; set; }
        public ICollection<Coat> Coats { get; set; }
        public ICollection<Dress> Dresses { get; set; }
        public ICollection<Panths> Pants { get; set; }
        public ICollection<Shirt> Shirts { get; set; }
        public ICollection<Boots> Boots { get; set; }
        public ICollection<CasualShoes> CasualShoes { get; set; }
        public ICollection<HighHeeledShoes> HighHeeledShoes { get; set; }
        public ICollection<Sandals> Sandals { get; set; }
        public ICollection<Slippers> Slippers { get; set; }
        public ICollection<Sport_Shoes> SportShoes { get; set; }
        public ICollection<Bags> Bags { get; set; }
        public ICollection<Belts> Belts { get; set; }
        public ICollection<Gloves> Gloves { get; set; }
        public ICollection<Jewelry> Jewelry { get; set; }
        public ICollection<Watches> Watches { get; set; }
    }
}
