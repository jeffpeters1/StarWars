﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace StarWars.CORE.Entities.Swapi
{
    public class SwapiSpecie : SwapiBase
    {
        private const string PathToEntity = "species/";

        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public string Classification { get; set; }

        [JsonProperty]
        public string Designation { get; set; }

        [JsonProperty(PropertyName = "average_height")]
        public string AverageHeight { get; set; }

        [JsonProperty(PropertyName = "average_lifespan")]
        public string AverageLifespan { get; set; }

        [JsonProperty(PropertyName = "eye_colors")]
        public string EyeColors { get; set; }

        [JsonProperty(PropertyName = "hair_colors")]
        public string HairColors { get; set; }

        [JsonProperty(PropertyName = "skin_colors")]
        public string SkinColors { get; set; }

        [JsonProperty]
        public string Language { get; set; }

        [JsonProperty]
        public string Homeworld { get; set; }

        [JsonProperty]
        public ICollection<string> People { get; set; }

        [JsonProperty]
        public ICollection<string> Films { get; set; }

        protected override string EntryPath
        {
            get
            {
                return PathToEntity;
            }
        }
    }
}
