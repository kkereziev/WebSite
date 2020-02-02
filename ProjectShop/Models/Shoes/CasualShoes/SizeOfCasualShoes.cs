using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectShop.Models.Shoes.CasualShoes
{
    public class SizeOfCasualShoes
    {
        public Guid Id { get; set; }
        public int SizeOfShoe { get; set; }

        public Guid ShoesId { get; set; }
        public CasualShoes Shoes { get; set; }
    }
}
