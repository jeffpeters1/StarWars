using System;
using System.Collections.Generic;

namespace StarWars.CORE.Entities.Main
{
    public class Film : BaseEntity
    {
        public string Title { get; set; }
        public int EpisodeId { get; set; }
        public string OpeningCrawl { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }
        public DateTime ReleaseDate { get; set; }

        // Many to many
        public ICollection<FilmPerson> Characters { get; set; }
        public ICollection<FilmSpecies> FilmSpecies { get; set; }
        public ICollection<FilmStarship> FilmStarships { get; set; }
        public ICollection<FilmVehicle> FilmVehicles { get; set; }
        public ICollection<FilmPlanet> FilmPlanets { get; set; }
    }
}
