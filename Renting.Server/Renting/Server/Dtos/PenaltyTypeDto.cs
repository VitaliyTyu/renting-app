using System.Text.Json.Serialization;

using Renting.DAL.Entities;

namespace Renting.Server.Dtos
{   
    public class PenaltyTypeDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public HarmLevel HarmLevel { get; set; }
    }
}
