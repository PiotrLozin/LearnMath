using LearnMath.Application.Teachers.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.Teachers.Queries
{
    public class GetTeacherByIdQuery : IRequest<TeacherDto>
    {
        public int Id { get; set; }
    }
}
