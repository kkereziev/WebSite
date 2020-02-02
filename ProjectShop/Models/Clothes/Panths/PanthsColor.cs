using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectShop.Models.Clothes.Panths
{
    public class PanthsColor
    {
        public Guid Id { get; set; }
        public string ColorOfPanths { get; set; }
        public Guid DressId { get; set; }
        public Panths Panths { get; set; }
    }
}
