using LearnMath.Application.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.Users.Commands.Handlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, int?>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int?> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var teacher = await _userRepository.GetById(request.Id);

            if (teacher == null)
            {
                return null;
            }

            var result = await _userRepository.Delete(teacher);
            return result;
        }
    }
}
