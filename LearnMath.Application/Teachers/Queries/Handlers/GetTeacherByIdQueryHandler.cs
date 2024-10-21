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

namespace LearnMath.Application.Teachers.Queries.Handlers
{
    public class GetTeacherByIdQueryHandler : IRequestHandler<GetTeacherByIdQuery, TeacherDto?>
    {
        private readonly IUserRepository _userRepository;

        public GetTeacherByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<TeacherDto?> Handle(GetTeacherByIdQuery request, CancellationToken cancellationToken)
        {
            var teacher = await _userRepository.GetById(request.Id);

            if (teacher == null)
            { 
                return null;
            }

            var teacherDto = teacher.MapToTeacherDto();
            teacherDto.Address = teacher.Address.MapToAddressDto();
            
            return teacherDto;
        }
    }
}
