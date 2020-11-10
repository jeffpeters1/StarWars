using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StarWars.API.Models;
using StarWars.API.Services;
using System;
using System.Collections.Generic;

namespace StarWars.API.Controllers
{
    [ApiController]
    [Route("api/films/{filmId}/planets")]
    public class PlanetController : Controller
    {
        private readonly IStarWarsRepository _starWarsRepository;
        private readonly IMapper _mapper;

        public PlanetController(IStarWarsRepository starWarsRepository, IMapper mapper)
        {
            _starWarsRepository = starWarsRepository
                ?? throw new ArgumentNullException(nameof(starWarsRepository));
            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlanetDto>> GetPlanetsForFilm(int filmId)
        {
            var list = new List<PlanetDto>();

            if (!_starWarsRepository.FilmExists(filmId))
            {
                return NotFound();
            }

            var planets = _starWarsRepository.GetPlanetsForFilm(filmId);

            foreach (var filmPlanet in planets)
            {
                list.Add(new PlanetDto()
                {
                    Id = filmPlanet.FilmId,
                    Name = filmPlanet.Planet.Name,
                    Diameter = filmPlanet.Planet.Diameter,
                    RotationPeriod = filmPlanet.Planet.RotationPeriod,
                    FilmId = filmPlanet.FilmId
                });
            }

            return Ok(list);
        }



    }
}
