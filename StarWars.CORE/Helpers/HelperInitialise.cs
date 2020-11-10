using StarWars.CORE.Entities.Swapi;
using System;
using System.Linq.Expressions;

namespace StarWars.CORE.Helpers
{
    public static class HelperInitialiser<T> where T : SwapiBase
    {
        public static readonly Func<T> Instance = Expression.Lambda<Func<T>>(Expression.New(typeof(T))).Compile();
    }
}
