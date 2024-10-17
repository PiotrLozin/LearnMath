using LearnMath.Application.Addresses;
using LearnMath.Domain;
using LearnMath.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.Students
{
    public class StudentDto
    {
        public StudentDto(int id, string firstName, string lastName, string email, Gender gender) 
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Gender = gender;
        }

        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public Gender Gender { get; set; }
        public AddressDto Address { get; set; }
    }
}
