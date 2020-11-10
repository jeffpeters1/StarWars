using System.Collections.Generic;

namespace StarWars.CORE.Entities.Main
{
    public class Species : BaseEntity
    {
        public string Name { get; set; }
        public string Classification { get; set; }
        public string Designation { get; set; }
        public string AverageHeight { get; set; }
        public string AverageLifespan { get; set; }
        public string EyeColours { get; set; }
        public string HairColours { get; set; }
        public string SkinColours { get; set; }
        public string Language { get; set; }
        public string Homeworld { get; set; }

        // Many to many relationship
        public ICollection<FilmSpecies> FilmSpecies { get; set; }
        public ICollection<PersonSpecies> PersonSpecies { get; set; }
    }
}
