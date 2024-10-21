using LearnMath.Application.Opinions.OpinionMappingProfile;
using LearnMath.Application.Teachers.MappingProfiles;
using LearnMath.Application.Users.MappingProfiles;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.Opinions.Queries.Handlers
{
    public class GetAllOpinionsByTeacherIdQueryHandler : IRequestHandler<GetAllOpinionsByTeacherIdQuery, GetAllOpinionsByTeacherIdResponse>
    {
        IOpinionRepository _opinionRepository;
        public GetAllOpinionsByTeacherIdQueryHandler(IOpinionRepository opinionRepository)
        {
            _opinionRepository = opinionRepository;
        }
        public async Task<GetAllOpinionsByTeacherIdResponse> Handle(GetAllOpinionsByTeacherIdQuery request, CancellationToken cancellationToken)
        {
            var userOpinions = await _opinionRepository.GetAllByTeacherId(request.TeacherId);
            var userOpinionsDto = userOpinions.Select(opinion =>
                {
                    var dto = opinion.MapToUserOpinionDto();
                    dto.Teacher = opinion.Teacher.MapToTeacherDto();
                    dto.Teacher.Address = opinion.Teacher.Address.MapToAddressDto();
                    return dto;
                }).ToList();
            return new GetAllOpinionsByTeacherIdResponse(userOpinionsDto);
        }
    }
}
