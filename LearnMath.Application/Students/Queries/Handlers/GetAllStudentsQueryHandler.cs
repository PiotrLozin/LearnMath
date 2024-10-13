using LearnMath.Application.Students.MappingProfiles;
using LearnMath.Application.Students.Responses;
using LearnMath.Application.Users;
using LearnMath.Application.Users.MappingProfiles;
using LearnMath.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.Students.Queries.Handlers
{
    internal class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, GetAllStudentsReponse>
    {
        private readonly IUserRepository _userRepository;

        public GetAllStudentsQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GetAllStudentsReponse> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            var students = await _userRepository.GetAll(UserType.Student);
            var studentsDto = students.Select(student => 
                {
                    var dto = student.MapToStudentDto();
                    dto.Address = student.Address.MapToAddressDto();
                    return dto;
                }).ToList();
            return new GetAllStudentsReponse(studentsDto);
        }
    }
}
