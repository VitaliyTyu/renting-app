using System;
using System.Text.Json.Serialization;

namespace Renting.DAL.Entities
{
    public class Discount : DbItem
    {
        public int Value { get; set; }
        public DateTime ActualFrom { get; set; }
        public DateTime ActualTo { get; set; }

        [JsonIgnore]
        public int? CustomerId { get; set; }
        [JsonIgnore]
        public Customer? Customer { get; set; }
    }
}
