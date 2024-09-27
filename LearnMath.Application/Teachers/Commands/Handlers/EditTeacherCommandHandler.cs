using LearnMath.Application.Teachers.Requests.Extensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.Teachers.Commands.Handlers
{
    public class EditTeacherCommandHandler : IRequestHandler<EditTeacherCommand, int?>
    {
        private readonly IUserRepository _userRepository;

        public EditTeacherCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int?> Handle(EditTeacherCommand request, CancellationToken cancellationToken)
        {
            var teacher = await _userRepository.GetById(request.Id);

            if (teacher == null)
            {
                return null;
            }

            var editedTeacher = request.EditTeacherRequest.EditTeacher(teacher);
            var result = await _userRepository.Update(editedTeacher);
            return result;

        }
    }
}
