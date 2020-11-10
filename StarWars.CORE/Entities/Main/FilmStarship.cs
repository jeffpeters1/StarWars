namespace StarWars.CORE.Entities.Main
{
    public class FilmStarship
    {
        public int FilmId { get; set; }
        public Film Film { get; set; }
        public int StarshipId { get; set; }
        public Starship Starship { get; set; }
    }
}
