using LearnMath.Application.Opinions.Requests;
using LearnMath.Application.Opinions.Reseponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.Opinions.Commands
{
    public class CreateOpinionCommand : IRequest<CreateOpinionResponse>
    {
        public CreateOpinionRequest OpinionRequest { get; set; }
        public CreateOpinionCommand(CreateOpinionRequest opinionRequest)
        {
            OpinionRequest = opinionRequest;
        }
    }
}
