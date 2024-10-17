using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.Opinions.Reseponses
{
    public class GetAllOpinionsResponse
    {
        public List<UserOpinionDto> Opinions { get; set; }
        public GetAllOpinionsResponse(List<UserOpinionDto> opinions)
        {
            Opinions = opinions;
        }
    }
}
