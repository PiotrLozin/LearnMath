using LearnMath.Application.Opinions.OpinionMappingProfile;
using LearnMath.Application.Teachers.MappingProfiles;
using LearnMath.Application.Users.MappingProfiles;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.Opinions.Queries.Handlers
{
    public class GetOpinionByIdQueryHandler : IRequestHandler<GetOpinionByIdQuery, UserOpinionDto?>
    {
        private readonly IOpinionRepository _opinionRepository;

        public GetOpinionByIdQueryHandler(IOpinionRepository opinionRepository)
        {
            _opinionRepository = opinionRepository;
        }

        public async Task<UserOpinionDto?> Handle(GetOpinionByIdQuery request, CancellationToken cancellationToken)
        {
            var userOpinion = await _opinionRepository.GetById(request.Id);

            if (userOpinion == null)
            {
                return null;
            }

            var userOpinionDto = userOpinion.MapToUserOpinionDto();
            userOpinionDto.Teacher = userOpinion.Teacher.MapToTeacherDto();
            userOpinionDto.Teacher.Address = userOpinion.Teacher.Address.MapToAddressDto();

            return userOpinionDto;
        }
    }
}
