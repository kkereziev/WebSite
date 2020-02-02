using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectShop.Models.Shoes.HighHeeledShoes
{
    public class HighHeeledShoesSize
    {
        public Guid Id { get; set; }
        public int SizeOfShoe { get; set; }

        public Guid ShoesId { get; set; }
        public HighHeeledShoes Shoes { get; set; }
    }
}
