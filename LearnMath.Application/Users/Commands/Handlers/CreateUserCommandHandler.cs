using LearnMath.Application.Teachers;
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
        public Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (request.UserType == UserType.Teacher)
            {
                var teacherEntity = request.UserRequest.MapToTeacher();

                var result = await _userRepository.Save(teacherEntity);

                return result;
            }
            var userEntity = request.
        }
    }
}
