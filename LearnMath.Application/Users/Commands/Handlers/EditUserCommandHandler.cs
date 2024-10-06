using LearnMath.Application.Users;
using LearnMath.Application.Users.Commands;
using LearnMath.Application.Users.Requests.Extensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.Users.Commands.Handlers
{
    public class EditUserCommandHandler : IRequestHandler<EditUserCommand, int?>
    {
        private readonly IUserRepository _userRepository;

        public EditUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int?> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            var teacher = await _userRepository.GetById(request.Id);

            if (teacher == null)
            {
                return null;
            }


            var editedTeacher = request.EditUserRequest.EditTeacher(teacher);
            var result = await _userRepository.Update(editedTeacher);
            return result;

        }
    }
}
