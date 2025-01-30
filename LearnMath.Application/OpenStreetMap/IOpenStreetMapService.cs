using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.OpenStreetMap
{
    public interface IOpenStreetMapService
    {
        Task<OSMResponseModel?> GetCoordinates(string city, string? postalCode = null);
    }
}
