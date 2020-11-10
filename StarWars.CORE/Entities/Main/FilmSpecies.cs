namespace StarWars.CORE.Entities.Main
{
    public class FilmSpecies
    {
        public int FilmId { get; set; }
        public Film Film { get; set; }
        public int SpeciesId { get; set; }
        public Species Species { get; set; }
    }
}
