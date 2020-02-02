using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectShop.Models.Shoes.HighHeeledShoes
{
    public class HighHeeledShoesColors
    {
        public Guid Id { get; set; }
        public string ColorOfShoe { get; set; }
        public Guid HighHeeledShoeId { get; set; }
        public HighHeeledShoes HighHeeledShoes { get; set; }
    }
}
