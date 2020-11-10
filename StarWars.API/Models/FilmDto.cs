using System;

namespace StarWars.API.Models
{
    public class FilmDto
    {
        public int Id { get; set; }

        public int EpisodeId { get; set; }

        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}
