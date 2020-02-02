using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectShop.Models.Shoes.Slippers
{
    public class SizeOfSlippers
    {
        public Guid Id { get; set; }
        public int SizeOfSlipper { get; set; }

        public Guid SlippersId { get; set; }
        public Slippers Slippers { get; set; }
    }
}
