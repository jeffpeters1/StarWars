namespace StarWars.CORE.Entities.Main
{
    public class PersonVehicle
    {
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
