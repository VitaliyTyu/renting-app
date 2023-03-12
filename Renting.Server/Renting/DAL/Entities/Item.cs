using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Renting.DAL.Entities
{
    public class Item : DbItem
    {
        public string Name { get; set; }
        public decimal RentalPrice { get; set; }
        public decimal BreakdownFee { get; set; }
        public double? SizeRu { get; set; }
        public double? Length { get; set; }
        public double? Width { get; set; }

        [JsonIgnore]
        public int? RentId { get; set; }
        [JsonIgnore]
        public Rent? Rent { get; set; }

        public int? CountryOfOriginId { get; set; }
        public CountryOfOrigin? CountryOfOrigin { get; set; }

        public int? WarehouseId { get; set; }
        public Warehouse? Warehouse { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
