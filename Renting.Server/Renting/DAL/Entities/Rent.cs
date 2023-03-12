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

        [JsonIgnore]
        public int UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }

        public int? CustomerId { get; set; } // todo убрать из базы
        public Customer? Customer { get; set; }

        public List<Item> Items { get; set; } = new List<Item>();
        public List<Penalty> Penalties { get; set; } = new List<Penalty>();
    }
}
