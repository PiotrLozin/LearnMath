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
    public class EditUserCommand : IRequest<int?>
    {
        public EditUserRequest EditUserRequest { get; set; }
        public int Id { get; set; }
        public EditUserCommand(EditUserRequest editUserRequest, int id)
        {
            EditUserRequest = editUserRequest;
            Id = id;
        }
    }
}
