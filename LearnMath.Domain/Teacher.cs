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
            //Subjects = subjects;
            Address = address;
            UserType = UserType.Teacher;
        }
    }
}