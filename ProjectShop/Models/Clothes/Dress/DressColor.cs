using System;

namespace ProjectShop.Models.Clothes.Dress
{
    public class DressColor
    {
        public Guid Id { get; set; }
        public string ColorOfDress { get; set; }
        public Guid ModelId { get; set; }
        public DressModel Model { get; set; }
    }
}
