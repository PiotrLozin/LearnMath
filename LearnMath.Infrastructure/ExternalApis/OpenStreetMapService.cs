using LearnMath.Application.OpenStreetMap;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LearnMath.Infrastructure.ExternalApis
{
    public class OpenStreetMapService : IOpenStreetMapService
    {
        private readonly HttpClient _httpClient;
        public OpenStreetMapService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<OSMResponseModel?> GetCoordinates(string city, string? postalCode = null)
        {
            string url = UrlBuilder(city, postalCode);

            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var results = JsonConvert.DeserializeObject<List<OSMResponseModel>>(json);
                return results?.FirstOrDefault();
            }

            return null;
        }

        /// <summary>
        /// The UrlBuilder for nominatim.
        /// </summary>
        /// <param name="city"></param>
        /// <param name="postalCode"></param>
        /// <returns></returns>
        private static string UrlBuilder(
            string city,
            string? postalCode = null)
        {
            string country = "Poland";
            var query = HttpUtility.ParseQueryString(string.Empty);
           
            // zobaczyć przykłady query.
            //query.Add

            // Dodajemy parametry
            query["country"] = country;
            query["city"] = city;

            if (postalCode != null)
            {
                query["postalcode"] = postalCode;
            }

            query["format"] = "jsonv2";
            query["addressdetails"] = "1";
            query["limit"] = "1";

            // Dołączamy zapytanie do URL
            return $"search?" + query.ToString();
        }
    }
}
