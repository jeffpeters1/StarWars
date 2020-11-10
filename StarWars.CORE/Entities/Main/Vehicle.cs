using System.Collections.Generic;

namespace StarWars.CORE.Entities.Main
{
    public class Vehicle : BaseEntity
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string VehicleClass { get; set; }
        public string Manufacturer { get; set; }
        public string Length { get; set; }
        public string CostInCredits { get; set; }
        public string Crew { get; set; }
        public string Passengers { get; set; }
        public string MaxAtmosphericSpeed { get; set; }
        public string CargoCapacity { get; set; }
        public string Consumables { get; set; }

        // Many to many relationship
        public ICollection<FilmVehicle> FilmVehicles { get; set; }
        public ICollection<PersonVehicle> Pilots { get; set; }
    }
}
