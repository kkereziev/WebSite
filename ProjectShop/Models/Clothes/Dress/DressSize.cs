using System;

namespace ProjectShop.Models.Clothes.Dress
{
    public class DressSize
    {
        public Guid Id { get; set; }
        public int SizeOfDress { get; set; }

        public Guid ModelId { get; set; }
        public DressModel Model { get; set; }
    }
}
