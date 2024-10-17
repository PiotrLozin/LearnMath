using LearnMath.Application.Addresses;
using LearnMath.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.Teachers
{
    public class TeacherDto
    {
        public TeacherDto(
            int id,
            string? firstName,
            string? lastName,
            string? profession,
            string? email,
            Gender gender)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Profession = profession;
            Email = email;
            Gender = gender;
        }
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Profession { get; set; }
        public string? Email { get; set; }
        public Gender Gender { get; set; }
        public AddressDto Address { get; set; }

    }
}
