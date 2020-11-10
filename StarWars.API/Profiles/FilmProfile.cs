using AutoMapper;
using StarWars.CORE.Entities.Main;

namespace StarWars.API.Profiles
{
    public class FilmProfile : Profile
    {
        public FilmProfile()
        {
            CreateMap<Film, Models.FilmDto>();
        }
    }
}
