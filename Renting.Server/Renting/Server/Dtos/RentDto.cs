using System.Collections.Generic;
using System;

namespace Renting.Server.Dtos
{
    public class RentDto
    {
        public DateTime StartDate { get; set; }
        public DateTime ExpectedEndDate { get; set; }
        public DateTime? ActualEndDate { get; set; }
        public CustomerDto Customer { get; set; }
        public List<ItemDto> Items { get; set; } = new List<ItemDto>();
        public List<PenaltyDto> Penalties { get; set; } = new List<PenaltyDto>();
    }
}
