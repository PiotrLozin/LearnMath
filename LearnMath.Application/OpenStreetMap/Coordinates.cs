using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.OpenStreetMap
{
    public class Coordinates
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Coordinates(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public override bool Equals(object obj)
        {
            // Sprawdź, czy obj to instancja Coordinates
            if (obj is Coordinates other)
            {
                return Latitude == other.Latitude 
                    && Longitude == other.Longitude;
            }

            return false;
        }
    }

}
