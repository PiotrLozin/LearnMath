using LearnMath.Application.Addresses;
using LearnMath.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.Users.Requests
{
    public record CreateUserRequest
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Profession { get; set; }
        public string? Email { get; set; }
        public Gender Gender { get; set; }
        public AddressDto Address { get; set; }
    }
}
