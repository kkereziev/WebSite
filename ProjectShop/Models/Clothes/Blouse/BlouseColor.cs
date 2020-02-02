using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectShop.Models.Clothes.Blouse
{
    public class BlouseColor
    {
        public Guid Id { get; set; }
        public string ColorOfBlouse { get; set; }
        public Guid ModelId { get; set; }
        public BlouseModel Model { get; set; }
    }
}
