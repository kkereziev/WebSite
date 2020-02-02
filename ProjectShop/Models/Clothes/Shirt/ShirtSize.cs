using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectShop.Models.Clothes.Shirt
{
    public class ShirtSize
    {
        public Guid Id { get; set; }
        public int SizeOfShirt { get; set; }

        public Guid ShirtId { get; set; }
        public Shirt Shirt { get; set; }
    }
}
