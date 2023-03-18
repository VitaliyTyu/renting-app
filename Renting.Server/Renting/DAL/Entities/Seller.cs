using System.Collections.Generic;

namespace Renting.DAL.Entities
{
    public class Seller : DbItem
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Rent> Rents { get; set; } = new List<Rent>();

        public string FullName => string.Format("{0} {1}", Surname, Name);
    }
}
