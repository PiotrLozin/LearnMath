using LearnMath.Application.Teachers.Requests;
using LearnMath.Application.Teachers.Requests.Extensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.Teachers.Commands.Handlers
{
    public class CreateTeacherCommandHandler : IRequestHandler<CreateTeacherCommand, int>
    {
        private readonly IUserRepository _userRepository;

        public CreateTeacherCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
        {
            var teacherEntity = request.TeacherRequest.MapToTeacher();

            var result = await _userRepository.Save(teacherEntity);

            return result;
        }
    }
}
