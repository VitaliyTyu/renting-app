using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Renting.Server.Dtos
{
    public class ItemDto
    {
        public string Name { get; set; }
        public decimal RentalPrice { get; set; }
        public decimal BreakdownFee { get; set; }
        public double? SizeRu { get; set; }
        public double? Length { get; set; }
        public double? Width { get; set; }

        public int? CountryOfOriginId { get; set; }
        public CountryOfOriginDto? CountryOfOrigin { get; set; }

        public int? WarehouseId { get; set; }
        public WarehouseDto? Warehouse { get; set; }

        public int? CategoryId { get; set; }
        public CategoryDto? Category { get; set; }
    }
}
