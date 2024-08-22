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
        private readonly ITeacherRepository _teacherRepository;

        public EditTeacherCommandHandler(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<int?> Handle(EditTeacherCommand request, CancellationToken cancellationToken)
        {
            var teacher = await _teacherRepository.GetById(request.Id);

            if (teacher == null)
            {
                return null;
            }

            var editedTeacher = request.EditTeacherRequest.EditTeacher(teacher);
            var result = await _teacherRepository.Update(editedTeacher);
            return result;

        }
    }
}
