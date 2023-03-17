using System.Collections.Generic;

namespace Renting.Server.Dtos
{
    public class UserDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Nickname { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }
}
