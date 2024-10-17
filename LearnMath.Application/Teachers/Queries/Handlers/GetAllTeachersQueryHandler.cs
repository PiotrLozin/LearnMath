using LearnMath.Application.Teachers.MappingProfiles;
using LearnMath.Application.Teachers.Responses;
using LearnMath.Application.Users;
using LearnMath.Application.Users.MappingProfiles;
using LearnMath.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.Teachers.Queries.Handlers
{
    internal class GetAllTeachersQueryHandler : IRequestHandler<GetAllTeachersQuery, GetAllTeacherResponse>
    {
        private readonly IUserRepository _userRepository;

        public GetAllTeachersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GetAllTeacherResponse> Handle(GetAllTeachersQuery request, CancellationToken cancellationToken)
        {
            var teachers = await _userRepository.GetAll(UserType.Teacher);
            var teachersDto = teachers.Select(teacher => 
                {
                    var dto = teacher.MapToTeacherDto();
                    dto.Address = teacher.Address.MapToAddressDto();
                    return dto;
                }).ToList();
            return new GetAllTeacherResponse(teachersDto);
        }
    }
}
