using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.Opinions.Commands
{
    public class DeleteOpinionCommand : IRequest<int?>
    {
        public int Id { get; set;}
        public DeleteOpinionCommand(int id)
        {
            Id = id;
        }
    }
}
