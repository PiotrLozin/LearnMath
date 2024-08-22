using LearnMath.Application.Addresses;
using LearnMath.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.Teachers.Requests.Extensions
{
    public static class EditTeacherRequestExtensions
    {
        public static Teacher EditTeacher(this EditTeacherRequest request, Teacher teacher) 
        {
            if (request == null) 
            {
                throw new ArgumentNullException(nameof(request));
            }

            teacher.FirstName = request.FirstName;
            teacher.LastName = request.LastName;
            teacher.Profession = request.Profession;
            teacher.Email = request.Email;
            teacher.Gender = request.Gender;
            teacher.Score = request.Score;
            teacher.NumberOfOpinions = request.NumberOfOpinions;
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
