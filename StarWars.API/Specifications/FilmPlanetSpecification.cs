using StarWars.CORE.Entities.Main;
using System;
using System.Linq.Expressions;

namespace StarWars.API.Specifications
{
    public class FilmPlanetSpecification : BaseSpecification<FilmPlanet>
    {
        public FilmPlanetSpecification(Expression<Func<FilmPlanet, bool>> criteria) : base(criteria)
        {
            AddIncludes();
        }

        public FilmPlanetSpecification(int filmId) : base(i => i.FilmId.Equals(filmId))
        {
            AddIncludes();
        }

        private void AddIncludes()
        {
            AddInclude(x => x.Film);
            AddInclude(x => x.Planet);
        }
    }
}
