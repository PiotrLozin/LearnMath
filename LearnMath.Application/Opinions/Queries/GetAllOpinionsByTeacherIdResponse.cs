using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.Opinions.Queries
{
    public class GetAllOpinionsByTeacherIdResponse
    {
        public List<UserOpinionDto> UserOpinions { get; set;}
        public GetAllOpinionsByTeacherIdResponse(List<UserOpinionDto> userOpinions)
        {
            UserOpinions = userOpinions;
        }
    }
}
