﻿using LearnMath.Application.OpenStreetMap;
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
        public async Task<Coordinates> GetCoordinates(string city, string? postalCode = null)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "LearnMath/1.0 (testaplikacji@wp.pl)");
            string url = UrlBuilder(city, postalCode);

            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var results = JsonConvert.DeserializeObject<List<OSMResponseModel>>(json);

                if (results != null && results.Any())
                {
                    var firstResult = results.First();
                    return new Coordinates(firstResult.Lat, firstResult.Lon);
                }
                else
                {
                    return new Coordinates(0, 0);
                }
            }

            return new Coordinates(0, 0);
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
            string baseUrl = "https://nominatim.openstreetmap.org/search";
            string country = "Poland";

            // Użycie UriBuilder do składania URL
            var uriBuilder = new UriBuilder(baseUrl);
            var query = HttpUtility.ParseQueryString(string.Empty);

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
            uriBuilder.Query = query.ToString();

            string url = uriBuilder.ToString();

            return url;
        }
    }
}
