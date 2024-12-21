using LearnMath.Application.OpenStreetMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.Addresses
{
    public class AddressDto
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }
        public Coordinates Coordinates { get; set; }

        public AddressDto(string street, string city, string country, string postCode, double longitude, double latitude)
        {
            Street = street;
            City = city;
            Country = country;
            PostCode = postCode;
            Coordinates = new Coordinates(longitude, latitude);
        }
    }
}
