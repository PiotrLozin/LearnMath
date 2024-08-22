using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using LearnMath.Domain.Enums;

namespace LearnMath.Domain
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Profession { get; set; }
        public string? Email { get; set; }
        public bool Gender { get; set; }
        public int Score { get; set; }
        public int NumberOfOpinions { get; set; }
        //public Subject[]? Subjects { get; set; }
        public Address Address { get; set; }

        public Teacher() { }

        public Teacher(
            int id,
            string firstName,
            string lastName,
            string profession,
            string email,
            bool gender,
            int score,
            int numberOfOpinions,
            //Subject[] subjects,
            Address address
        )
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Profession = profession;
            Email = email;
            Gender = gender;
            Score = score;
            NumberOfOpinions = numberOfOpinions;
            //Subjects = subjects;
            Address = address;
        }
    }
}