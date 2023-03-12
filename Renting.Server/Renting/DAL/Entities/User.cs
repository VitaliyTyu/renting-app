using System.Collections.Generic;

namespace Renting.DAL.Entities
{
    public class User : DbItem
    {
        public string? Name { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public List<Rent> Rents { get; set; } = new List<Rent>();
    }
}
