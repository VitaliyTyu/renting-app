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

        [JsonIgnore]
        public int? RentId { get; set; }
        [JsonIgnore]
        public Rent? Rent { get; set; }

        public List<Discount> Discounts { get; set; } = new List<Discount>();
    }
}
