using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StarWars.API.Models;
using StarWars.API.Services;
using System;
using System.Collections.Generic;

namespace StarWars.API.Controllers
{
    [ApiController]
    [Route("api/films")]
    public class FilmController : Controller
    {
        private readonly IStarWarsRepository _starWarsRepository;
        private readonly IMapper _mapper;

        public FilmController(IStarWarsRepository starWarsRepository, IMapper mapper)
        {
            _starWarsRepository = starWarsRepository
                ?? throw new ArgumentNullException(nameof(starWarsRepository));
            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet()]
        public ActionResult<IEnumerable<FilmDto>> GetFilms()
        {
            var films = _starWarsRepository.GetAll();
            return Ok(_mapper.Map<IEnumerable<FilmDto>>(films));
        }

        [HttpGet("{filmId}", Name = "GetFilm")]
        public IActionResult GetFilm(int filmId)
        {
            var film = _starWarsRepository.GetById(filmId);
            return Ok(_mapper.Map<FilmDto>(film));
        }
    }
}
