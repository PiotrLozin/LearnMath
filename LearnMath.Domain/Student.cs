using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using LearnMath.Domain.Enums;

namespace LearnMath.Domain
{
    public class Student : User
    {
        public Student() { }

        public Student(
            int id,
            string firstName,
            string lastName,
            string email,
            Gender gender,
            Address address
        )
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Gender = gender;
            Address = address;
        }
    }
}