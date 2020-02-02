using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectShop.Models.Shoes.CasualShoes
{
    public class ColorOfCasualShoes
    {
        public Guid Id { get; set; }
        public string ColorOfShoe { get; set; }
        public Guid CasualShoesId { get; set; }
        public CasualShoes CasualShoes { get; set; }
    }
}
