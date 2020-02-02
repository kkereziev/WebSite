using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectShop.Models.Accessories.Watches
{
    public class StylesOfWatches
    {
        public Guid Id { get; set; }
        public string StyleOfWatch { get; set; }
        public Guid WatchId { get; set; }
        public Watches Watch { get; set; }
    }
}
