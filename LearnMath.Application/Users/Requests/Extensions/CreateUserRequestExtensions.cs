using LearnMath.Application.Addresses;
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
        public static User MapToUser(this CreateUserRequest request, UserType userType)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (!Enum.IsDefined(typeof(Gender), request.Gender))
            {
                throw new ArgumentException($"Invalid gender value: {request.Gender}", nameof(request.Gender));
            }

            User userEntity = new User(
                default,
                request.FirstName,
                request.LastName,
                request.Profession,
                request.Email,
                request.Gender,
                request.Address.MapToAddress(),
                userType);

            return userEntity;
        }

        public static Address MapToAddress(this AddressDto request)
        {
            Address address = new Address(
                Guid.Empty,
                request.Street,
                request.City,
                request.Country,
                request.PostCode);

            return address;
        }
    }
}
