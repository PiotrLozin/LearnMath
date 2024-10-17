using LearnMath.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.Opinions.OpinionMappingProfile
{
    public static class OpinionMappingProfile
    {
        public static UserOpinionDto MapToUserOpinionDto(this UserOpinion userOpinion)
        {
            UserOpinionDto userOpinionDto = new UserOpinionDto(
                userOpinion.Id,
                userOpinion.Score,
                userOpinion.Description,
                userOpinion.CreatedByUser);

            return userOpinionDto;
        }
    }
}
