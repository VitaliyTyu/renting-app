using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Renting.DAL.Entities
{
    public class Penalty : DbItem
    {
        public string? Name { get; set; }
        public decimal Value { get; set; }

        //[JsonIgnore]
        public int? RentId { get; set; }
        //[JsonIgnore]
        public Rent? Rent { get; set; }

        public List<PenaltyType> PenaltyTypes { get; set; } = new List<PenaltyType>();
    }
}
