using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.OpenStreetMap.Queries.Handlers
{
    public class GetCoordinatesQueryHandler : IRequestHandler<GetCoordinatesQuery, Coordinates>
    {
        private readonly IOpenStreetMapService _openStreetMapService;

        public GetCoordinatesQueryHandler(IOpenStreetMapService openStreetMapService)
        {
            _openStreetMapService = openStreetMapService;
        }

        public async Task<Coordinates> Handle(GetCoordinatesQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.City))
            {
                throw new ArgumentException("City cannot be null or empty.");
            }

            var coordinates = await _openStreetMapService.GetCoordinates(request.City, request.PostalCode);

            if (coordinates is null || coordinates.Equals(new Coordinates(0, 0)))
            {
                throw new InvalidOperationException("The specified address could not be resolved to coordinates.");
            }

            return new Coordinates(coordinates.Lat, coordinates.Lon);
        }
    }

}
