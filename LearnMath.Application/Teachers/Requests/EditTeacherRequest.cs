using LearnMath.Application.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.Teachers.Requests
{
    public class EditTeacherRequest
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Profession { get; set; }
        public string? Email { get; set; }
        public bool Gender { get; set; }
        public int Score { get; set; }
        public int NumberOfOpinions { get; set; }
        public AddressDto AddressForm { get; set; }
    }
}
