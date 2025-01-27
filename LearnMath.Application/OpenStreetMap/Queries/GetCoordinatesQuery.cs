using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.OpenStreetMap.Queries
{
    public class GetCoordinatesQuery : IRequest<Coordinates>
    {
        public string City { get; set; }
        public string? PostalCode { get; set; }

        public GetCoordinatesQuery(string city, string? postalCode = null)
        {
            City = city;
            PostalCode = postalCode;
        }
    }

}
