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
        private readonly IUserRepository _userRepository;

        public DeleteTeacherCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int?> Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
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
