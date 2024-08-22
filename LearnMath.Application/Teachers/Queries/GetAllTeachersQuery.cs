using LearnMath.Application.Teachers.Responses;
using LearnMath.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.Teachers.Queries
{
    public class GetAllTeachersQuery : IRequest<GetAllTeacherResponse>
    {
    }
}
