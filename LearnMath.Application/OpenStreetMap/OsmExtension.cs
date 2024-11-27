using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.OpenStreetMap
{
    public static class OsmExtension
    {
        /// <summary>
        /// The method to GetCoordinates of the city from OSM.
        /// </summary>
        /// <param name="city">
        /// Requested City.
        /// </param>
        /// <returns>
        /// Point with coordinates of the requested city.
        /// </returns>
        public static async Task<Coordinates> GetCoordinates(string city)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "LearnMath/1.0 (testaplikacji@wp.pl)");
            string url = $"https://nominatim.openstreetmap.org/search?addressdetails=1&q={city}&format=jsonv2&limit=1";

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
    }
}
