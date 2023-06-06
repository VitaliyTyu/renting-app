using System.Collections.Generic;
using System.Text.Json.Serialization;

using Renting.DAL.Interfaces;

namespace Renting.DAL.Entities
{
    public class Customer : DbItem, NamedEntity
    {
        public string Name { get; set; }
        public string? Surname { get; set; }
        public int? Age { get; set; }
        public int? Height { get; set; }
        public int? Weight { get; set; }
        public double? ShoeSizeRu { get; set; }
        public double? ClothingSizeRu { get; set; }

        public string? AccountId { get; set; }
        public Account? Account { get; set; }

        public List<Rent> Rents { get; set; } = new List<Rent>();

        public List<Discount> Discounts { get; set; } = new List<Discount>();


        public string FullName => string.Format("{0} {1}", Surname, Name);
    }
}
