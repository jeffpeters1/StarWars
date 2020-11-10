using Newtonsoft.Json;
using StarWars.CORE.Entities.Swapi;
using StarWars.CORE.Helpers;
using StarWars.CORE.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace StarWars.CORE.Services
{
    public class Repository<T> : IRepository<T> where T : SwapiBase
    {
        private const string BASE_ADDRESS = "http://swapi.dev/api/";
        private readonly T entity;
        private const int DefaultPage = 1;

        public Repository()
        {
            this.entity = HelperInitialiser<T>.Instance();
        }

        public ICollection<T> GetEntities(int page = DefaultPage)
        {
            var url = GetUrl(page);
            IEnumerable<T> results = new List<T>();

            var helper = new Helper<T>()
            {
                Next = url,
                Previous = null,
            };

            while (helper.Next != null)
            {
                //Get JSON
                var json = GetJson(helper.Next);
                if (json == null)
                {
                    return null;
                }

                //Get Helper (wrapper around results)
                helper = JsonConvert.DeserializeObject<Helper<T>>(json);
                if (helper == null)
                {
                    return null;
                }

                //Get Entity results
                results = results.Union(helper.Results);
            }

            return results.ToList();
        }

        private string GetJson(string url)
        {
            try
            {
                var request = WebRequest.Create(url);
                var response = request.GetResponse();

                string json = string.Empty;
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    json = reader.ReadToEnd();
                }

                return json;
            }
            catch (WebException ex)
            {
                //// todo: Check status when there are no Internet connection. 
                return null;
            }
        }

        private string GetUrl(int page)
        {
            var pageString = page > 0 ? "?page=" + page : string.Empty;

            return $"{BASE_ADDRESS}{entity.GetPath()}" + pageString;
        }
    }
}
