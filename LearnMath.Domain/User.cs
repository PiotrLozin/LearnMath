using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using LearnMath.Domain.Enums;

namespace LearnMath.Domain
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Profession { get; set; }
        public string? Email { get; set; }
        public Gender Gender { get; set; }
        public Address Address { get; set; }
        public UserType UserType { get; set; }
        public virtual List<UserOpinion> Opinions { get; set; }
        public User() { }

        public User(
            int id,
            string firstName,
            string lastName,
            string profession,
            string email,
            Gender gender,
            Address address,
            UserType userType
        )
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Profession = profession;
            Email = email;
            Gender = gender;
            Address = address;
            UserType = userType;
        }

        public void AddOpinion( UserOpinion opinion )
        {
            Opinions.Add( opinion );
        }
    }
}