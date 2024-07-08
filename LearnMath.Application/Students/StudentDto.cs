using LearnMath.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.Students
{
    public class StudentDto
    {
        public StudentDto(string firstName, string lastName, string email, bool gender) 
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Gender = gender;
        }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public bool Gender { get; set; }
    }
}
