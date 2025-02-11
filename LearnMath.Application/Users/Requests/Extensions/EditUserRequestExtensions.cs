using LearnMath.Application.Addresses;
using LearnMath.Application.OpenStreetMap;
using LearnMath.Application.Users.Requests;
using LearnMath.Domain;
using LearnMath.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.Users.Requests.Extensions
{
    public static class EditUserRequestExtensions
    {
        public static User EditTeacher(this EditUserRequest request, User teacher, Coordinates coordinates)
        {
            teacher.FirstName = request.FirstName;
            teacher.LastName = request.LastName;
            teacher.Email = request.Email;
            teacher.Gender = request.Gender;
            teacher.Address = request.Address.EditAddress(teacher.Address, coordinates);

            return teacher;
        }

        public static Address EditAddress(this AddressDto addressDto, Address address, Coordinates coordinates)
        {
            address.Street = addressDto.Street;
            address.City = addressDto.City;
            address.PostCode = addressDto.PostCode;
            address.Country = addressDto.Country;
            address.Longitude = coordinates.Longitude;
            address.Latitude = coordinates.Latitude;

            return address;
        }
    }
}
