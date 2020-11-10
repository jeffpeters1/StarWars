namespace StarWars.CORE.Entities.Main
{
    public class PersonStarship
    {
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int StarshipId { get; set; }
        public Starship Starship { get; set; }
    }
}
