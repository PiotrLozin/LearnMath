using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.Opinions.Commands.Handlers
{
    public class EditOpinionCommandHandler : IRequestHandler<EditOpinionCommand, int?>
    {
        private readonly IOpinionRepository _opinionRepository;
        public EditOpinionCommandHandler(IOpinionRepository opinionRepository)
        {
            _opinionRepository = opinionRepository;
        }
        public async Task<int?> Handle(EditOpinionCommand request, CancellationToken cancellationToken)
        {
            var userOpinion = await _opinionRepository.GetById(request.Id);

            if (userOpinion == null || request == null)
            {
                return null;
            }

            userOpinion.Score = (int)request.EditOpinionRequest.Score;
            userOpinion.Description = (string)request.EditOpinionRequest.Description;
            var result = await _opinionRepository.Update(userOpinion);
            return result;
        }
    }
}
