using System.Collections.Generic;
using System;

namespace Renting.Server.Dtos
{
    public class RentDto
    {
        public DateTime StartDate { get; set; }
        public DateTime ExpectedEndDate { get; set; }
        public DateTime? ActualEndDate { get; set; }
        public decimal Price { get; set; }
        public string? Note { get; set; }
        public CustomerDto Customer { get; set; }
        public ItemDto Item { get; set; }
        public UserDto User { get; set; }
    }
}
