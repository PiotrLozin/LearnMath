using LearnMath.Application.Teachers.MappingProfiles;
using LearnMath.Application.Teachers.Responses;
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
        private readonly ITeacherRepository _teacherRepository;

        public GetAllTeachersQueryHandler(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<GetAllTeacherResponse> Handle(GetAllTeachersQuery request, CancellationToken cancellationToken)
        {
            var teachers = await _teacherRepository.GetAll();
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
