using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWars.CORE.Entities.Main;

namespace StarWars.DATA
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Film> Films { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Starship> Starships { get; set; }
        public DbSet<Species> Species { get; set; }
        public DbSet<Planet> Planets { get; set; }

        public DbSet<FilmPlanet> FilmPlanet { get; set; }
        public DbSet<FilmStarship> FilmStarship { get; set; }
        public DbSet<FilmVehicle> FilmVehicle { get; set; }
        public DbSet<FilmSpecies> FilmSpecie { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Film>(ConfigureFilms);
            builder.Entity<Person>(ConfigurePeople);
            builder.Entity<Vehicle>(ConfigureVehicles);
            builder.Entity<Starship>(ConfigureStarships);
            builder.Entity<Species>(ConfigureSpecies);
            builder.Entity<Planet>(ConfigurePlanets);

            // Many to many
            builder.Entity<FilmPerson>(ConfigureFilmPerson);
            builder.Entity<FilmSpecies>(ConfigureFilmSpecie);
            builder.Entity<FilmStarship>(ConfigureFilmStarship);
            builder.Entity<FilmVehicle>(ConfigureFilmVehicle);
            builder.Entity<FilmPlanet>(ConfigureFilmPlanet);
            builder.Entity<PersonSpecies>(ConfigurePersonSpecie);
            builder.Entity<PersonStarship>(ConfigurePersonStarship);
            builder.Entity<PersonVehicle>(ConfigurePersonVehicle);

            base.OnModelCreating(builder);
        }

        private static void ConfigureFilms(EntityTypeBuilder<Film> builder)
        {
            builder.ToTable("Films");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.EpisodeId).IsRequired();
            builder.Property(x => x.OpeningCrawl).IsRequired(false);
            builder.Property(x => x.Director).IsRequired();
            builder.Property(x => x.Producer).IsRequired();
            builder.Property(x => x.ReleaseDate).IsRequired();
        }

        private static void ConfigurePeople(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("People");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.BirthYear).IsRequired();
            builder.Property(x => x.EyeColour).IsRequired();
            builder.Property(x => x.Gender).IsRequired();
            builder.Property(x => x.HairColour).IsRequired();
            builder.Property(x => x.Height).IsRequired();
            builder.Property(x => x.Mass).IsRequired();
            builder.Property(x => x.SkinColour).IsRequired();

            // One to many relationship
            builder.HasOne(x => x.Homeworld)
                   .WithMany(p => p.Residents)
                   .HasForeignKey(x => x.PlanetId)
                   .IsRequired().OnDelete(DeleteBehavior.Cascade);
        }

        private static void ConfigureVehicles(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("Vehicles");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Model).IsRequired();
            builder.Property(x => x.VehicleClass).IsRequired();
            builder.Property(x => x.Manufacturer).IsRequired();
            builder.Property(x => x.CostInCredits).IsRequired();
            builder.Property(x => x.Length).IsRequired();
            builder.Property(x => x.Crew).IsRequired();
            builder.Property(x => x.Passengers).IsRequired();
            builder.Property(x => x.MaxAtmosphericSpeed).IsRequired();
            builder.Property(x => x.CargoCapacity).IsRequired();
            builder.Property(x => x.Consumables).IsRequired();
        }

        private static void ConfigureStarships(EntityTypeBuilder<Starship> builder)
        {
            builder.ToTable("Starships");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Model).IsRequired();
            builder.Property(x => x.StarshipClass).IsRequired();
            builder.Property(x => x.Manufacturer).IsRequired();
            builder.Property(x => x.CostInCredits).IsRequired();
            builder.Property(x => x.Length).IsRequired();
            builder.Property(x => x.Crew).IsRequired();
            builder.Property(x => x.Passengers).IsRequired();
            builder.Property(x => x.MaxAtmosphericSpeed).IsRequired();
            builder.Property(x => x.HyperdriveRating).IsRequired();
            builder.Property(x => x.MGLT).IsRequired();
            builder.Property(x => x.CargoCapacity).IsRequired();
            builder.Property(x => x.Consumables).IsRequired();
        }

        private static void ConfigureSpecies(EntityTypeBuilder<Species> builder)
        {
            builder.ToTable("Species");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Classification).IsRequired();
            builder.Property(x => x.Designation).IsRequired();
            builder.Property(x => x.AverageHeight).IsRequired();
            builder.Property(x => x.AverageLifespan).IsRequired();
            builder.Property(x => x.EyeColours).IsRequired();
            builder.Property(x => x.HairColours).IsRequired();
            builder.Property(x => x.SkinColours).IsRequired();
            builder.Property(x => x.Language).IsRequired();
            builder.Property(x => x.Homeworld).IsRequired(false);

            // One to many relationship
            //builder.HasOne(x => x.Homeworld)
            //       .WithMany(s => s.Species)
            //       .HasForeignKey(x => x.PlanetId)
            //       .IsRequired().OnDelete(DeleteBehavior.Cascade);
        }

        private static void ConfigurePlanets(EntityTypeBuilder<Planet> builder)
        {
            builder.ToTable("Planets");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Diameter).IsRequired();
            builder.Property(x => x.RotationPeriod).IsRequired();
            builder.Property(x => x.OrbitalPeriod).IsRequired();
            builder.Property(x => x.Gravity).IsRequired();
            //builder.Property(x => x.Population).IsRequired();
            builder.Property(x => x.Climate).IsRequired();
            builder.Property(x => x.Terrain).IsRequired();
            builder.Property(x => x.SurfaceWater).IsRequired();
        }

        // Many to many relationships
        private static void ConfigureFilmPerson(EntityTypeBuilder<FilmPerson> builder)
        {
            builder.ToTable("FilmPerson");

            builder.HasKey(fp => new { fp.FilmId, fp.PersonId });

            builder.HasOne(fp => fp.Film)
                   .WithMany(f => f.Characters)
                   .HasForeignKey(fp => fp.FilmId);

            builder.HasOne(fp => fp.Person)
                   .WithMany(p => p.FilmPeople)
                   .HasForeignKey(fp => fp.PersonId);
        }

        private static void ConfigureFilmSpecie(EntityTypeBuilder<FilmSpecies> builder)
        {
            builder.ToTable("FilmSpecie");

            builder.HasKey(fs => new { fs.FilmId, fs.SpeciesId });

            builder.HasOne(fs => fs.Film)
                   .WithMany(f => f.FilmSpecies)
                   .HasForeignKey(fs => fs.FilmId);

            builder.HasOne(fs => fs.Species)
                   .WithMany(s => s.FilmSpecies)
                   .HasForeignKey(fs => fs.SpeciesId);
        }

        private static void ConfigureFilmStarship(EntityTypeBuilder<FilmStarship> builder)
        {
            builder.ToTable("FilmStarship");

            builder.HasKey(fs => new { fs.FilmId, fs.StarshipId });

            builder.HasOne(fs => fs.Film)
                   .WithMany(f => f.FilmStarships)
                   .HasForeignKey(fs => fs.FilmId);

            builder.HasOne(fs => fs.Starship)
                   .WithMany(s => s.FilmStarships)
                   .HasForeignKey(fs => fs.StarshipId);
        }

        private static void ConfigureFilmVehicle(EntityTypeBuilder<FilmVehicle> builder)
        {
            builder.ToTable("FilmVehicle");

            builder.HasKey(fv => new { fv.FilmId, fv.VehicleId });

            builder.HasOne(fv => fv.Film)
                   .WithMany(f => f.FilmVehicles)
                   .HasForeignKey(fv => fv.FilmId);

            builder.HasOne(fv => fv.Vehicle)
                   .WithMany(v => v.FilmVehicles)
                   .HasForeignKey(fv => fv.VehicleId);
        }

        private static void ConfigureFilmPlanet(EntityTypeBuilder<FilmPlanet> builder)
        {
            builder.ToTable("FilmPlanet");

            builder.HasKey(fp => new { fp.FilmId, fp.PlanetId });

            builder.HasOne(fp => fp.Film)
                   .WithMany(f => f.FilmPlanets)
                   .HasForeignKey(fp => fp.FilmId);

            builder.HasOne(fp => fp.Planet)
                   .WithMany(p => p.FilmPlanets)
                   .HasForeignKey(fp => fp.PlanetId);
        }

        private static void ConfigurePersonSpecie(EntityTypeBuilder<PersonSpecies> builder)
        {
            builder.ToTable("PersonSpecie");

            builder.HasKey(ps => new { ps.PersonId, ps.SpeciesId });

            builder.HasOne(ps => ps.Person)
                   .WithMany(p => p.PersonSpecies)
                   .HasForeignKey(ps => ps.PersonId);

            builder.HasOne(ps => ps.Species)
                   .WithMany(s => s.PersonSpecies)
                   .HasForeignKey(ps => ps.SpeciesId);
        }

        private static void ConfigurePersonStarship(EntityTypeBuilder<PersonStarship> builder)
        {
            builder.ToTable("PersonStarship");

            builder.HasKey(ps => new { ps.PersonId, ps.StarshipId });

            builder.HasOne(ps => ps.Person)
                   .WithMany(p => p.PersonStarships)
                   .HasForeignKey(ps => ps.PersonId);

            builder.HasOne(ps => ps.Starship)
                   .WithMany(s => s.Pilots)
                   .HasForeignKey(ps => ps.StarshipId);
        }

        private static void ConfigurePersonVehicle(EntityTypeBuilder<PersonVehicle> builder)
        {
            builder.ToTable("PersonVehicle");

            builder.HasKey(pv => new { pv.PersonId, pv.VehicleId });

            builder.HasOne(pv => pv.Person)
                   .WithMany(p => p.PersonVehicles)
                   .HasForeignKey(pv => pv.PersonId);

            builder.HasOne(pv => pv.Vehicle)
                   .WithMany(v => v.Pilots)
                   .HasForeignKey(pv => pv.VehicleId);
        }
    }
}
