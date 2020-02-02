using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectShop.Models.Clothes.Coat
{
    public class CoatSize
    {
        public Guid Id { get; set; }
        public int SizeOfCoat { get; set; }

        public Guid ModelId { get; set; }
        public CoatModel Model { get; set; }
    }
}
