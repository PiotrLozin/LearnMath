using LearnMath.Application.Addresses;
using LearnMath.Application.Students;
using LearnMath.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.Students.MappingProfiles
{
    public static class StudentMappingProfile
    {
        public static StudentDto MapToStudent(this User student)
        {
            StudentDto studentDto = new StudentDto(
                student.Id,
                student.FirstName,
                student.LastName,
                student.Email,
                student.Gender);

            return studentDto;
        }
    }
}
