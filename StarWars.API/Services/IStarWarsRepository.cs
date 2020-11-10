using StarWars.CORE.Entities.Main;
using System.Collections.Generic;

namespace StarWars.API.Services
{
    public interface IStarWarsRepository
    {
        IEnumerable<Film> GetAll();
        Film GetById(int id);
        bool FilmExists(int id);

        IEnumerable<FilmPlanet> GetPlanetsForFilm(int filmId);
    }
}
