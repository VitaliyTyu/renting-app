using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Renting.Server.Dtos
{
    public class PenaltyDto
    {
        public string? Name { get; set; }
        public decimal Value { get; set; }

        public List<PenaltyTypeDto> PenaltyTypes { get; set; } = new List<PenaltyTypeDto>();
    }
}
