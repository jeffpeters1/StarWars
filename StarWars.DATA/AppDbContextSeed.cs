using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StarWars.CORE.Entities.Main;
using StarWars.CORE.Entities.Swapi;
using StarWars.CORE.Interfaces;
using StarWars.CORE.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.DATA
{
    public class AppDbContextSeed
    {
        public static async Task SeedAsync(AppDbContext context, ILoggerFactory loggerFactory, int? retry = 0)
        {
            var retryForAvailability = retry;

            try
            {
                await context.Database.MigrateAsync();

                if (!context.Planets.Any())
                {
                    await context.Planets.AddRangeAsync(GetPlanets());
                    await context.SaveChangesAsync();
                }

                if (!context.Starships.Any())
                {
                    await context.Starships.AddRangeAsync(GetStarships());
                    await context.SaveChangesAsync();
                }

                if (!context.Vehicles.Any())
                {
                    await context.Vehicles.AddRangeAsync(GetVehicles());
                    await context.SaveChangesAsync();
                }

                if (!context.Species.Any())
                {
                    await context.Species.AddRangeAsync(GetSpecies());
                    await context.SaveChangesAsync();
                }

                if (!context.Films.Any())
                {
                    var tuple = GetFilms();

                    await context.Films.AddRangeAsync(tuple.Item1);
                    await context.FilmPlanet.AddRangeAsync(tuple.Item2);
                    await context.FilmStarship.AddRangeAsync(tuple.Item3);
                    await context.FilmVehicle.AddRangeAsync(tuple.Item4);
                    await context.FilmSpecie.AddRangeAsync(tuple.Item5);
                    await context.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<AppDbContextSeed>();
                    log.LogError(ex.Message);
                    await SeedAsync(context, loggerFactory, retryForAvailability);
                }

            }

        }

        private static IEnumerable<Planet> GetPlanets()
        {
            IRepository<SwapiPlanet> repo = new Repository<SwapiPlanet>();
            var planets = repo.GetEntities();
            var list = new List<Planet>();

            foreach (var planet in planets)
            {
                var id = GetId(planet.Url);

                list.Add(new Planet()
                {
                    Id = id,
                    Created = planet.Created,
                    Edited = planet.Edited,
                    Climate = planet.Climate,
                    Diameter = planet.Diameter,
                    Gravity = planet.Gravity,
                    Name = planet.Name,
                    Terrain = planet.Terrain,
                    RotationPeriod = planet.RotationPeriod,
                    SurfaceWater = planet.SurfaceWater,
                    OrbitalPeriod = planet.OrbitalPeriod
                });
            }

            return list;
        }

        private static IEnumerable<Starship> GetStarships()
        {
            IRepository<SwapiStarship> repo = new Repository<SwapiStarship>();
            var starships = repo.GetEntities();
            var list = new List<Starship>();

            foreach (var starship in starships)
            {
                var id = GetId(starship.Url);

                list.Add(new Starship()
                {
                    Id = id,
                    Created = starship.Created,
                    Edited = starship.Edited,
                    Name = starship.Name,
                    Model = starship.Model,
                    CargoCapacity = starship.CargoCapacity,
                    Consumables = starship.Consumables,
                    CostInCredits = starship.CostInCredits,
                    Crew = starship.Crew,
                    HyperdriveRating = starship.HyperdriveRating,
                    Length = starship.Length,
                    Manufacturer = starship.Manufacturer,
                    MaxAtmosphericSpeed = starship.Manufacturer,
                    MGLT = starship.MegaLights,
                    StarshipClass = starship.StarshipClass,
                    Passengers = starship.Passengers
                });
            }

            return list;
        }

        private static IEnumerable<Vehicle> GetVehicles()
        {
            IRepository<SwapiVehicle> repo = new Repository<SwapiVehicle>();
            var vehicles = repo.GetEntities();
            var list = new List<Vehicle>();

            foreach (var vehicle in vehicles)
            {
                var id = GetId(vehicle.Url);

                list.Add(new Vehicle()
                {
                    Id = id,
                    Created = vehicle.Created,
                    Edited = vehicle.Edited,
                    Name = vehicle.Name,
                    Model = vehicle.Model,
                    CargoCapacity = vehicle.CargoCapacity,
                    Consumables = vehicle.Consumables,
                    CostInCredits = vehicle.CostInCredits,
                    Crew = vehicle.Crew,
                    Length = vehicle.Length,
                    Manufacturer = vehicle.Manufacturer,
                    MaxAtmosphericSpeed = vehicle.Manufacturer,
                    VehicleClass = vehicle.VehicleClass,
                    Passengers = vehicle.Passengers
                });
            }

            return list;
        }

        private static IEnumerable<Species> GetSpecies()
        {
            IRepository<SwapiSpecie> repo = new Repository<SwapiSpecie>();
            var species = repo.GetEntities();
            var list = new List<Species>();

            foreach (var specie in species)
            {
                var id = GetId(specie.Url);

                list.Add(new Species()
                {
                    Id = id,
                    Created = specie.Created,
                    Edited = specie.Edited,
                    AverageHeight = specie.AverageHeight,
                    AverageLifespan = specie.AverageLifespan,
                    Classification = specie.Classification,
                    Designation = specie.Designation,
                    EyeColours = specie.EyeColors,
                    HairColours = specie.HairColors,
                    Homeworld = string.IsNullOrEmpty(specie.Homeworld) ? string.Empty : GetId(specie.Homeworld).ToString(),
                    Language = specie.Language,
                    Name = specie.Name,
                    SkinColours = specie.SkinColors
                });
            }

            return list;
        }

        private static Tuple<IEnumerable<Film>, IEnumerable<FilmPlanet>, IEnumerable<FilmStarship>, IEnumerable<FilmVehicle>, IEnumerable<FilmSpecies>>  GetFilms()
        {
            IRepository<SwapiFilm> repo = new Repository<SwapiFilm>();
            var films = repo.GetEntities();
            var list = new List<Film>();
            var filmPlanets = new List<FilmPlanet>();
            var filmStarships = new List<FilmStarship>();
            var filmVehicles = new List<FilmVehicle>();
            var filmSpecies = new List<FilmSpecies>();

            foreach (var film in films)
            {
                var id = GetId(film.Url);

                list.Add(new Film()
                {
                    Id = id,
                    Created = film.Created,
                    Edited = film.Edited,
                    Director = film.Director,
                    EpisodeId = int.Parse(film.EpisodeId),
                    Producer = film.Producer,
                    OpeningCrawl = film.OpeningCrawl,
                    Title = film.Title,
                    ReleaseDate = DateTime.Parse(film.ReleaseDate)
                });

                // Many to many relationships
                foreach (var planet in film.Planets)
                {
                    var planetId = GetId(planet);
                    filmPlanets.Add(new FilmPlanet() { FilmId = id, PlanetId = planetId });
                }

                foreach (var starship in film.Starships)
                {
                    var starshipId = GetId(starship);
                    filmStarships.Add(new FilmStarship() { FilmId = id, StarshipId = starshipId });
                }

                foreach (var vehicle in film.Vehicles)
                {
                    var vehicleId = GetId(vehicle);
                    filmVehicles.Add(new FilmVehicle() { FilmId = id, VehicleId = vehicleId });
                }

                foreach (var species in film.Species)
                {
                    var speciesId = GetId(species);
                    filmSpecies.Add(new FilmSpecies() { FilmId = id, SpeciesId = speciesId });
                }
            }

            //return list;
            return new Tuple<IEnumerable<Film>, 
                             IEnumerable<FilmPlanet>, 
                             IEnumerable<FilmStarship>,
                             IEnumerable<FilmVehicle>,
                             IEnumerable<FilmSpecies>>
                    (list, filmPlanets, filmStarships, filmVehicles, filmSpecies);
        }

        

        private static int GetId(string url)
        {
            int secondSlash = url.LastIndexOf("/");
            int firstSlash = url.LastIndexOf("/", secondSlash - 1);
            int lengthOfSubstring = (secondSlash - firstSlash) - 1;
            string stringId = url.Substring(firstSlash + 1, lengthOfSubstring);
            int id = int.Parse(stringId);

            return id;
        }
    }
}
