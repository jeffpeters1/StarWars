using Microsoft.EntityFrameworkCore;
using StarWars.API.Specifications;
using StarWars.CORE.Entities.Main;
using StarWars.DATA;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StarWars.API.Services
{
    public class StarWarsRepository : IStarWarsRepository
    {
        private readonly AppDbContext _context;

        public StarWarsRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        //========================
        // FILMS
        //========================
        public IEnumerable<Film> GetAll()
        {
            return _context.Films
                           .OrderBy(m => m.Title)
                           .ToList();
        }

        public Film GetById(int id)
        {
            if (id == 0)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return _context.Films.FirstOrDefault(f => f.Id == id);
        }

        public bool FilmExists(int id)
        {
            return _context.Films.Any(f => f.Id == id);
        }

        //========================
        // PLANETS
        //========================
        public IEnumerable<FilmPlanet> GetPlanetsForFilm(int filmId)
        {
            var spec = new FilmPlanetSpecification(filmId);

            // fetch a Queryable that includes all expression-based includes
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(_context.Set<FilmPlanet>().AsQueryable(),
                    (current, include) => current.Include(include));

            // modify the IQueryable to include any string-based include statements
            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            var result = secondaryResult.Where(spec.Criteria).AsEnumerable().ToList();

            return result;
        }



    }
}
