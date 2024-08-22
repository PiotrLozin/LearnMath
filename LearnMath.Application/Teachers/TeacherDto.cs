using LearnMath.Application.Addresses;
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
            bool gender,
            int score,
            int numberOfOpinions)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Profession = profession;
            Email = email;
            Gender = gender;
            Score = score;
            NumberOfOpinions = numberOfOpinions;
        }
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Profession { get; set; }
        public string? Email { get; set; }
        public bool Gender { get; set; }
        public int Score { get; set; }
        public int NumberOfOpinions { get; set; }
        public AddressDto Address { get; set; }

    }
}
