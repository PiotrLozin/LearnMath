using LearnMath.Application.Users.Requests;
using LearnMath.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.Users.Commands
{
    public class CreateUserCommand : IRequest<int>
    {
        public CreateUserRequest UserRequest { get; set; }
        public UserType UserType { get; set; }
        public CreateUserCommand(CreateUserRequest userRequest, UserType userType)
        {
            UserRequest = userRequest;
            UserType = userType;
        }
    }
}
