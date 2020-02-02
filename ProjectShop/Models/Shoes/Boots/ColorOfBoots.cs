using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectShop.Models.Shoes.Boots
{
    public class ColorOfBoots
    {
        public Guid Id { get; set; }
        public string _ColorOfBoots { get; set; }
        public Guid ModelId { get; set; }
        public BootsModel Model { get; set; }
    }
}
