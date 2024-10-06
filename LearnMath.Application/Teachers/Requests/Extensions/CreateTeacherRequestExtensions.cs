﻿using LearnMath.Application.Addresses;
using LearnMath.Domain;
using LearnMath.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.Teachers.Requests.Extensions
{
    public static class CreateTeacherRequestExtensions
    {
        public static Teacher MapToTeacher(this CreateTeacherRequest request)
        {
            if (request is null) 
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (!Enum.IsDefined(typeof(Gender), request.Gender))
            {
                throw new ArgumentException($"Invalid gender value: {request.Gender}", nameof(request.Gender));
            }

            Teacher teacherEntity = new Teacher(
                default,
                request.FirstName,
                request.LastName,
                request.Profession,
                request.Email,
                request.Gender,
                request.Address.MapToAddress());

            return teacherEntity;
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
