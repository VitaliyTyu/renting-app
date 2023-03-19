using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Renting.DAL.Entities
{
    public class Rent : DbItem
    {
        public DateTime StartDate { get; set; }
        public DateTime ExpectedEndDate { get; set; }
        public DateTime? ActualEndDate { get; set; }

        public string? AccountId { get; set; }
        public Account? Account { get; set; }

        public int? SellerId { get; set; }
        public Seller? Seller { get; set; }

        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public int? ItemId { get; set; }
        public Item? Item { get; set; }

        public List<Penalty> Penalties { get; set; } = new List<Penalty>();
    }
}
