using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.Opinions.Queries
{
    public class GetOpinionByIdQuery : IRequest<UserOpinionDto>
    {
        public int Id { get; set; }
    }
}
