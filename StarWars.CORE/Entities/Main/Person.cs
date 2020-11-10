using StarWars.CORE.Enums;
using System.Collections.Generic;

namespace StarWars.CORE.Entities.Main
{
    public class Person : BaseEntity
    {
        public string Name { get; set; }
        public string BirthYear { get; set; }
        public string EyeColour { get; set; }
        public Gender Gender { get; set; }
        public string HairColour { get; set; }
        public float Height { get; set; }
        public float Mass { get; set; }
        public string SkinColour { get; set; }

        // One to many relationship
        public int PlanetId { get; set; }
        public Planet Homeworld { get; set; }

        // Many to many relationship
        public ICollection<FilmPerson> FilmPeople { get; set; }
        public ICollection<PersonSpecies> PersonSpecies { get; set; }
        public ICollection<PersonStarship> PersonStarships { get; set; }
        public ICollection<PersonVehicle> PersonVehicles { get; set; }
    }
}
