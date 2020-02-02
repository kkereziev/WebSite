using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectShop.Models.Clothes.Panths
{
    public class PanthsSize
    {
        public Guid Id { get; set; }
        public int SizeOfPanths { get; set; }

        public Guid PanthsId { get; set; }
        public Panths Panths { get; set; }
    }
}
