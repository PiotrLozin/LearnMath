using LearnMath.Application.Addresses;
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
        public static User EditTeacher(this EditUserRequest request, User teacher)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (!Enum.IsDefined(typeof(Gender), request.Gender))
            {
                throw new ArgumentException($"Invalid gender value: {request.Gender}", nameof(request.Gender));
            }

            if (!Enum.IsDefined(typeof(Subject), request.Profession))
            {
                throw new ArgumentException($"Invalid gender value: {request.Profession}", nameof(request.Profession));
            }

            teacher.FirstName = request.FirstName;
            teacher.LastName = request.LastName;
            teacher.Profession = request.Profession;
            teacher.Email = request.Email;
            teacher.Gender = request.Gender;
            teacher.Address = request.AddressForm.EditAddress(teacher.Address);

            return teacher;
        }

        public static Address EditAddress(this AddressDto addressDto, Address address)
        {
            address.Street = addressDto.Street;
            address.City = addressDto.City;
            address.PostCode = addressDto.PostCode;
            address.Country = addressDto.Country;

            return address;
        }
    }
}
