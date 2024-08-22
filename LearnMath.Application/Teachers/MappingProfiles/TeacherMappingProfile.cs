﻿using LearnMath.Application.Addresses;
using LearnMath.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.Teachers.MappingProfiles
{
    public static class TeacherMappingProfile
    {
        public static TeacherDto MapToTeacherDto(this Teacher teacher)
        {
            TeacherDto teacherDto = new TeacherDto(
                teacher.Id,
                teacher.FirstName,
                teacher.LastName,
                teacher.Profession,
                teacher.Email,
                teacher.Gender,
                teacher.Score,
                teacher.NumberOfOpinions);

            return teacherDto;
        }

        public static AddressDto MapToAddressDto(this Address address)
        {
            AddressDto addressDto = new AddressDto(
                address.Street,
                address.City,
                address.Country,
                address.PostCode);

            return addressDto;
        }
    }
}