using LearnMath.Application.Teachers.MappingProfiles;
using LearnMath.Application.Teachers.Responses;
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
        private readonly ITeacherRepository _teacherRepository;

        public GetTeacherByIdQueryHandler(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<TeacherDto?> Handle(GetTeacherByIdQuery request, CancellationToken cancellationToken)
        {
            var teacher = await _teacherRepository.GetById(request.Id);

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
