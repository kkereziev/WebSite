using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectShop.Models.Shoes.Sandals
{
    public class SizeOfSandals
    {
        public Guid Id { get; set; }
        public int SizeOfSandal { get; set; }

        public Guid SandalsId { get; set; }
        public Sandals Sandals { get; set; }
    }
}
