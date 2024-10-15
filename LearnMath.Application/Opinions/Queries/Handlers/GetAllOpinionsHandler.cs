using LearnMath.Application.Opinions.OpinionMappingProfile;
using LearnMath.Application.Opinions.Reseponses;
using LearnMath.Application.Teachers.MappingProfiles;
using LearnMath.Application.Students.MappingProfiles;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearnMath.Application.Users.MappingProfiles;

namespace LearnMath.Application.Opinions.Queries.Handlers
{
    public class GetAllOpinionsHandler : IRequestHandler<GetAllOpinionsQuery, GetAllOpinionsResponse>
    {
        private readonly IOpinionRepository _opinionRepository;

        public GetAllOpinionsHandler(IOpinionRepository opinionRepository)
        {
            _opinionRepository = opinionRepository;
        }

        public async Task<GetAllOpinionsResponse> Handle(GetAllOpinionsQuery request, CancellationToken cancellationToken)
        {
            var opinions = await _opinionRepository.GetAll();
            var opinionsDto = opinions.Select(opinion =>
                {
                    var dto = opinion.MapToUserOpinionDto();
                    dto.Teacher = opinion.Teacher.MapToTeacherDto();
                    dto.Teacher.Address = opinion.Teacher.Address.MapToAddressDto();
                    dto.CreatedByUser = opinion.CreatedByUser;
                    return dto;
                }).ToList();
            return new GetAllOpinionsResponse(opinionsDto);
        }
    }
}
