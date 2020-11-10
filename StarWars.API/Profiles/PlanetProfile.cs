using AutoMapper;
using StarWars.CORE.Entities.Main;

namespace StarWars.API.Profiles
{
    public class PlanetProfile : Profile
    {
        public PlanetProfile()
        {
            CreateMap<FilmPlanet, Models.PlanetDto>();
        }
    }
}
