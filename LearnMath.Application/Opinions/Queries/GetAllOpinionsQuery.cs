using LearnMath.Application.Opinions.Reseponses;
using LearnMath.Application.Teachers.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.Opinions.Queries
{
    public class GetAllOpinionsQuery : IRequest<GetAllOpinionsResponse>
    {
    }
}
