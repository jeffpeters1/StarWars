using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.CORE.Entities.Main
{
    public class Planet : BaseEntity
    {
        public string Name { get; set; }
        public string Diameter { get; set; }
        public string RotationPeriod { get; set; }
        public string OrbitalPeriod { get; set; }
        public string Gravity { get; set; }
        public string Climate { get; set; }
        public string Terrain { get; set; }
        public string SurfaceWater { get; set; }

        // One to many relationship
        public ICollection<Person> Residents { get; set; }

        // Many to many relationship
        public ICollection<FilmPlanet> FilmPlanets { get; set; }
    }
}
