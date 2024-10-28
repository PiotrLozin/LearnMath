using LearnMath.Application.Addresses;
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
        public static TeacherDto MapToTeacherDto(this User teacher)
        {
            var total = teacher.Opinions.Count;
            TeacherDto teacherDto = new TeacherDto(
                teacher.Id,
                teacher.FirstName,
                teacher.LastName,
                teacher.Profession,
                teacher.Email,
                teacher.Gender,
                total);

            return teacherDto;
        }
    }
}
