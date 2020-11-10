namespace StarWars.CORE.Entities.Main
{
    public class FilmVehicle
    {
        public int FilmId { get; set; }
        public Film Film { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
