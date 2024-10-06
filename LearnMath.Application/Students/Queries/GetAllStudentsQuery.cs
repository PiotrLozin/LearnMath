using LearnMath.Application.Students.Responses;
using LearnMath.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.Students.Queries
{
    public class GetAllStudentsQuery : IRequest<GetAllStudentsReponse>
    {
    }
}
