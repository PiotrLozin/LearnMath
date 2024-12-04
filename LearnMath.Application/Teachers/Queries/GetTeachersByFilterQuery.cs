using LearnMath.Application.Teachers.Responses;
using LearnMath.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.Teachers.Queries
{
    public class GetTeachersByFilterQuery : IRequest<GetAllTeacherResponse>
    {
        public Subject? Subject { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public int Score { get; set; }
        public int Distance { get; set; }
    }
}
