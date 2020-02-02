using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectShop.Models.Shoes.SportShoes
{
    public class ColorOfShoes
    {
        public Guid Id { get; set; }
        public string ColorOfShoe { get; set; }
        public Guid ShoesId { get; set; }
        public Sport_Shoes Shoes { get; set; }
    }
}
