namespace StarWars.CORE.Entities.Main
{
    public class FilmPlanet
    {
        public int FilmId { get; set; }
        public Film Film { get; set; }
        public int PlanetId { get; set; }
        public Planet Planet { get; set; }
    }
}
