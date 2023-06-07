using System.Collections.Generic;
using System.Text.Json.Serialization;

using Renting.DAL.Interfaces;

namespace Renting.DAL.Entities
{
    public class Item : DbItem, NamedEntity
    {

        public string? AccountId { get; set; }
        public Account? Account { get; set; }
        public string Name { get; set; } = "";
        public decimal RentalPrice { get; set; }
        public decimal MarketPrice { get; set; }
        public decimal BreakdownFee { get; set; }
        public double? SizeRu { get; set; }
        public double? Length { get; set; }
        public double? Width { get; set; }

        public List<Rent> Rents { get; set; } = new List<Rent>();

        public int? CountryOfOriginId { get; set; }
        public CountryOfOrigin? CountryOfOrigin { get; set; }

        public int? WarehouseId { get; set; }
        public Warehouse? Warehouse { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
