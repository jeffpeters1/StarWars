namespace StarWars.CORE.Entities.Main
{
    public class FilmPerson
    {
        public int FilmId { get; set; }
        public Film Film { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
