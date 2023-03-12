using System.Collections.Generic;

namespace Renting.DAL.Entities
{
    public class Category : DbItem
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Note { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
    }
}
