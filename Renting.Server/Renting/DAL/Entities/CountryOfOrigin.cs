using System.Collections.Generic;

namespace Renting.DAL.Entities
{
    public class CountryOfOrigin : DbItem
    {
        public string Name { get; set; }
        public string? Location { get; set; }
        public decimal? ApprovalRating { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
    }
}
