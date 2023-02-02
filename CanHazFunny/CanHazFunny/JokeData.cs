using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CanHazFunny
{
    public record JokeData
    {
        [JsonPropertyName("joke")]
        public string? Joke { get; set; }
        
    }
}
