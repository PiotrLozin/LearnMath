using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using LearnMath.Domain.Enums;

namespace LearnMath.Domain
{
    public class Teacher : User
    {
        public Teacher() { }

        public Teacher(
            int id,
            string firstName,
            string lastName,
            string profession,
            string email,
            Gender gender,
            Address address
        )
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Profession = profession;
            Email = email;
            Gender = gender;
            Address = address;
            UserType = UserType.Teacher;
        }
    }
}