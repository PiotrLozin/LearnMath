using LearnMath.Application.Addresses;
using LearnMath.Domain.Enums;
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
        public Gender Gender { get; set; }
        public AddressDto AddressForm { get; set; }
    }
}
