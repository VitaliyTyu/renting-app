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
        public decimal Price { get; set; }
        public string? Note { get; set; }

        public int? UserId { get; set; }
        public User? User { get; set; }

        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public int? ItemId { get; set; }
        public Item? Item { get; set; }

        public List<Penalty> Penalties { get; set; } = new List<Penalty>();
    }
}
