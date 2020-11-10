using Newtonsoft.Json;
using System;

namespace StarWars.CORE.Entities.Swapi
{
    public abstract class SwapiBase
    {
        [JsonProperty]
        public int Id { get; set; }

        [JsonProperty]
        public string Url { get; set; }

        [JsonProperty]
        public DateTime Created { get; set; }

        [JsonProperty]
        public DateTime Edited { get; set; }

        protected abstract string EntryPath { get; }

        public string GetPath()
        {
            return this.EntryPath;
        }
    }
}
