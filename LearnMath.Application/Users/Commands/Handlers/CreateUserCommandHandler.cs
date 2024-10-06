using LearnMath.Application.Teachers;
using LearnMath.Application.Users.Requests.Extensions;
using LearnMath.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.Users.Commands.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userEntity = request.UserRequest.MapToUser();

            var result = await _userRepository.Save(userEntity);

            return result;
        }
    }
}
