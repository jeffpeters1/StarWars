namespace StarWars.CORE.Entities.Main
{
    public class PersonSpecies
    {
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int SpeciesId { get; set; }
        public Species Species { get; set; }
    }
}
