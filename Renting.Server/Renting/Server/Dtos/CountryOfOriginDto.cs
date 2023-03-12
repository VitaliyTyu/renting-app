using System.Collections.Generic;

namespace Renting.Server.Dtos
{
    public class CountryOfOriginDto
    {
        public string Name { get; set; }
        public string? Location { get; set; }
        public decimal? ApprovalRating { get; set; }
    }
}
