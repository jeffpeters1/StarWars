namespace StarWars.API.Models
{
    public class PlanetDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Diameter { get; set; }
        public string RotationPeriod { get; set; }

        public int FilmId { get; set; }
    }
}
