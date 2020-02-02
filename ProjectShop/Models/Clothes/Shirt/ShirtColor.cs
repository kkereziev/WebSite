using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectShop.Models.Clothes.Shirt
{
    public class ShirtColor
    {
        public Guid Id { get; set; }
        public string ColorOfShirt { get; set; }
        public Guid ShirtId { get; set; }
        public Shirt Shirt { get; set; }
    }
}
