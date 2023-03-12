using System.Text.Json.Serialization;

namespace Renting.DAL.Entities
{
    public enum HarmLevel
    {
        Low,
        Medium, 
        High
    }

    public class PenaltyType : DbItem
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public HarmLevel HarmLevel { get; set; }

        [JsonIgnore]
        public int? PenaltyId { get; set; }
        [JsonIgnore]
        public Penalty? Penalty { get; set; }
    }
}
