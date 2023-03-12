using System.Collections.Generic;

namespace Renting.DAL.Entities
{
    public class Warehouse : DbItem
    {
        public string Name { get; set; }
        public string? Address { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
    }
}
