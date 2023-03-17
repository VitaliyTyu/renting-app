using System.Collections.Generic;
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
        public List<Penalty> Penalties { get; set; } = new List<Penalty>();
    }
}
