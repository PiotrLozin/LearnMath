using LearnMath.Application.Addresses;
using LearnMath.Application.OpenStreetMap;
using LearnMath.Domain;
using LearnMath.Domain.Enums;
using MediatR;
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
        public static User MapToDBUser(this CreateUserRequest request, UserType userType, AddressDto address)
        {
            User userEntity = new User(
                default,
                request.FirstName,
                request.LastName,
                request.Email,
                request.Gender,
                address.MapToDBAddress(),
                userType)
            {
                UserSubjects = request.Subjects.MapToDBUserSubject()
            };

            return userEntity;
        }

        public static Address MapToDBAddress(this AddressDto adressDto)
        {
            Address address = new Address(
                Guid.Empty,
                adressDto.Street,
                adressDto.City,
                adressDto.Country,
                adressDto.PostCode);

            return address;
        }

        public static List<UserSubject> MapToDBUserSubject(this List<Subject> subjects) 
        {
            return subjects
                    .Select(subject => new UserSubject { Subject = subject })
                    .ToList();
        }

    }
}
