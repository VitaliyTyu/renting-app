using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

using Microsoft.AspNetCore.Identity;

namespace Renting.DAL.Entities
{
    public class Account : IdentityUser
    {
        public Account()
        {
        }

        public Account(string email, string password)
        {
            var passwordHasher = new PasswordHasher<Account>();
            var hashedPassword = passwordHasher.HashPassword(this, password);

            base.Email = email;
            base.UserName = email;
            base.PasswordHash = hashedPassword;
        }
        public string? Inn { get; set; }
        public List<Rent> Rents { get; set; } = new List<Rent>();
    }
}
