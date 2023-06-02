using System.Collections.Generic;

using Renting.DAL.Interfaces;

namespace Renting.DAL.Entities
{
    public class Seller : DbItem, NamedEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Rent> Rents { get; set; } = new List<Rent>();

        public string FullName => string.Format("{0} {1}", Surname, Name);
    }
}
