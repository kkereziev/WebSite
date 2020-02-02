using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectShop.Models.Shoes.Boots
{
    public class SizeOfBoots
    {
        public Guid Id { get; set; }
        public int SizeOfBoot { get; set; }
        public Guid ModelId { get; set; }
        public BootsModel Model { get; set; }
    }
}
