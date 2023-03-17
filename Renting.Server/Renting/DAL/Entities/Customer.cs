using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Renting.DAL.Entities
{
    public class Customer : DbItem
    {
        public string Name { get; set; }
        public string? Surname { get; set; }
        public int? Age { get; set; }
        public int? Height { get; set; }
        public int? Weight { get; set; }
        public double? ShoeSizeRu { get; set; }
        public double? ClothingSizeRu { get; set; }

        public List<Rent> Rent { get; set; } = new List<Rent>();

        public List<Discount> Discounts { get; set; } = new List<Discount>();
    }
}
