using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectShop.Models.Shoes.Sandals
{
    public class ColorOfSandals
    {
        public Guid Id { get; set; }
        public string ColorOfSandal { get; set; }
        public Guid SandalsId { get; set; }
        public Sandals Sandals { get; set; }
    }
}
