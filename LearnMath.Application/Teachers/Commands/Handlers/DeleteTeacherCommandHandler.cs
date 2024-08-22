using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.Teachers.Commands.Handlers
{
    public class DeleteTeacherCommandHandler : IRequestHandler<DeleteTeacherCommand, int?>
    {
        private readonly ITeacherRepository _teacherRepository;

        public DeleteTeacherCommandHandler(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<int?> Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
        {
            var teacher = await _teacherRepository.GetById(request.Id);
            
            if (teacher == null)
            {
                return null;
            }

            var result = await _teacherRepository.Delete(teacher);
            return result;
        }
    }
}
