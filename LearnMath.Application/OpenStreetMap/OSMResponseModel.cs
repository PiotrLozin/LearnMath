using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.OpenStreetMap
{
    public class OSMResponseModel
    {
        public long PlaceId { get; set; }
        public string Licence { get; set; }
        public string OsmType { get; set; }
        public long OsmId { get; set; }
        public double Lat { get; set; } // Jeśli wolisz double, zmień na double
        public double Lon { get; set; } // Jeśli wolisz double, zmień na double
        public string Class { get; set; }
        public string Type { get; set; }
        public int PlaceRank { get; set; }
        public double Importance { get; set; }
        public string Addresstype { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public List<string> Boundingbox { get; set; }
    }
}
