using LearnMath.Application.Addresses;
using LearnMath.Application.OpenStreetMap;
using LearnMath.Domain;
using LearnMath.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.Users.Requests.Extensions
{
    public static class CreateUserRequestExtensions
    {
        public static async Task<User> MapToUserAsync(this CreateUserRequest request, UserType userType)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (!Enum.IsDefined(typeof(Gender), request.Gender))
            {
                throw new ArgumentException($"Invalid gender value: {request.Gender}", nameof(request.Gender));
            }

            if (request.Subjects == null || !request.Subjects.All(s => Enum.IsDefined(typeof(Subject), s)))
            {
                throw new ArgumentException("Invalid subjects in the list.", nameof(request.Subjects));
            }

            User userEntity = new User(
                default,
                request.FirstName,
                request.LastName,
                request.Email,
                request.Gender,
                await request.Address.MapToAddress(),
                userType)
            {
                UserSubjects = request.Subjects
                    .Select(subject => new UserSubject { Subject = subject })
                    .ToList()
            };

            return userEntity;
        }

        public static async Task<Address> MapToAddress(this AddressDto request)
        {
            Address address = new Address(
                Guid.Empty,
                request.Street,
                request.City,
                request.Country,
                request.PostCode);

            Coordinates coordinates = await OsmExtension.GetCoordinates(request.City);
            address.Latitude = coordinates.Latitude;
            address.Longitude = coordinates.Longitude;

            return address;
        }
    }
}
