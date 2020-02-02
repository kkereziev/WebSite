using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectShop.Models.Shoes.Slippers
{
    public class ColorOfSlippers
    {
        public Guid Id { get; set; }
        public string ColorOfSlipper { get; set; }
        public Guid SlippersId { get; set; }
        public Slippers Slippers { get; set; }
    }
}
