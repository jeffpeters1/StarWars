using Newtonsoft.Json;
using StarWars.CORE.Entities.Swapi;
using System.Collections.Generic;

namespace StarWars.CORE.Helpers
{
    internal class Helper<T> where T : SwapiBase
    {
        [JsonProperty]
        public ICollection<T> Results { get; set; }

        [JsonProperty]
        public int Count { get; set; }

        [JsonProperty]
        public string Next { get; set; }

        [JsonProperty]
        public string Previous { get; set; }
    }
}
