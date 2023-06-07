using System.Collections.Generic;

using Renting.DAL.Interfaces;

namespace Renting.DAL.Entities
{
    public class Category : DbItem, NamedEntity
    {
        public string? AccountId { get; set; }
        public Account? Account { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Note { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
    }
}
