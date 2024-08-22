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
        private readonly ITeacherRepository _teacherRepository;

        public CreateTeacherCommandHandler(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<int> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
        {
            var teacherEntity = request.TeacherRequest.MapToTeacher();

            var result = await _teacherRepository.Save(teacherEntity);

            return result;
        }
    }
}
