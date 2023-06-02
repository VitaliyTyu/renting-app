using System.Collections.Generic;
using System.Text.Json.Serialization;

using Renting.DAL.Interfaces;

namespace Renting.DAL.Entities
{
    public class Penalty : DbItem, NamedEntity
    {
        public decimal Value { get; set; }
        public string Name { get; set; } = "";
        public string? Description { get; set; }

        public int? RentId { get; set; }
        public Rent? Rent { get; set; }

        public int? PenaltyTypeId { get; set; }
        public PenaltyType? PenaltyType { get; set; }
    }
}
