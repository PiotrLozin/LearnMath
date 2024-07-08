using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using LearnMath.Domain.Enums;

namespace LearnMath.Domain
{
    public class Student
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public bool Gender { get; set; }
        //public Subject[]? Subjects { get; set; }
        public Address Address { get; set; }

        public Student() { }

        public Student(
            Guid id,
            string firstName,
            string lastName,
            string email,
            bool gender,
            //Subject[] subjects,
            Address address
        )
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Gender = gender;
            //Subjects = subjects;
            Address = address;
        }
    }
}