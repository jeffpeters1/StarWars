using StarWars.CORE.Entities.Swapi;
using System.Collections.Generic;

namespace StarWars.CORE.Interfaces
{
    public interface IRepository<T> where T : SwapiBase
    {
        ICollection<T> GetEntities(int page = 1);
    }
}
