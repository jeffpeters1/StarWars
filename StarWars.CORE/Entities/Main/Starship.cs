using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.CORE.Entities.Main
{
    public class Starship : BaseEntity
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string StarshipClass { get; set; }
        public string Manufacturer { get; set; }
        public string CostInCredits { get; set; }
        public string Length { get; set; }
        public string Crew { get; set; }
        public string Passengers { get; set; }
        public string MaxAtmosphericSpeed { get; set; }
        public string HyperdriveRating { get; set; }
        public string MGLT { get; set; }
        public string CargoCapacity { get; set; }
        public string Consumables { get; set; }


        // Many to many relationship
        public ICollection<FilmStarship> FilmStarships { get; set; }
        public ICollection<PersonStarship> Pilots { get; set; }
    }
}
