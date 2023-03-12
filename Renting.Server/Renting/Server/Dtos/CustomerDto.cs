using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Renting.Server.Dtos
{
    public class CustomerDto
    {
        public string Name { get; set; }
        public string? Surname { get; set; }
        public int? Age { get; set; }
        public int? Height { get; set; }
        public int? Weight { get; set; }
        public double? ShoeSizeRu { get; set; }
        public double? ClothingSizeRu { get; set; }
        public List<DiscountDto> Discounts { get; set; } = new List<DiscountDto>();
    }
}
