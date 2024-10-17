using LearnMath.Application.Students.MappingProfiles;
using LearnMath.Application.Teachers.MappingProfiles;
using LearnMath.Application.Teachers.Responses;
using LearnMath.Application.Users;
using LearnMath.Application.Users.MappingProfiles;
using LearnMath.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.Students.Queries.Handlers
{
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, StudentDto?>
    {
        private readonly IUserRepository _userRepository;

        public GetStudentByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<StudentDto?> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _userRepository.GetById(request.Id);

            if (student == null)
            { 
                return null;
            }

            var studentDto = student.MapToStudentDto();
            studentDto.Address = student.Address.MapToAddressDto();
            
            return studentDto;
        }
    }
}
