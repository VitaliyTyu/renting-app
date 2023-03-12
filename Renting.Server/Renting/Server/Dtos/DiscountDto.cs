using System;
using System.Text.Json.Serialization;

namespace Renting.Server.Dtos
{
    public class DiscountDto
    {
        public int Value { get; set; }
        public DateTime ActualFrom { get; set; }
        public DateTime ActualTo { get; set; }
    }
}
