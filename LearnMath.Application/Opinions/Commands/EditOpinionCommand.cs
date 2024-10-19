using LearnMath.Application.Opinions.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.Opinions.Commands
{
    public class EditOpinionCommand : IRequest<int?>
    {
        public EditOpinionRequest EditOpinionRequest { get; set; }
        public int Id { get; set; }
        public EditOpinionCommand(EditOpinionRequest editOpinionRequest, int id)
        {
            EditOpinionRequest = editOpinionRequest;
            Id = id;
        }
    }
}
