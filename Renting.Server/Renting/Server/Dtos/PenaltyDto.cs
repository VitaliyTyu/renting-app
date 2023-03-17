using System.Collections.Generic;
using System.Text.Json.Serialization;

using Renting.DAL.Entities;

namespace Renting.Server.Dtos
{
    public class PenaltyDto
    {
        public string? Name { get; set; }
        public decimal Value { get; set; }

        public int? RentId { get; set; }
        public RentDto? Rent { get; set; }

        public int? PenaltyTypeId { get; set; }
        public PenaltyTypeDto? PenaltyType { get; set; }
    }
}
