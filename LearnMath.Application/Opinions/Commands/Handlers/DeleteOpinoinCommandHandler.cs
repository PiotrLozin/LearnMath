using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.Opinions.Commands.Handlers
{
    public class DeleteOpinoinCommandHandler : IRequestHandler<DeleteOpinionCommand, int?>
    {
        private readonly IOpinionRepository _opinionRepository;

        public DeleteOpinoinCommandHandler(IOpinionRepository opinionRepository)
        {
            _opinionRepository = opinionRepository;
        }
        public async Task<int?> Handle(DeleteOpinionCommand request, CancellationToken cancellationToken)
        {
            var opinion = await _opinionRepository.GetById(request.Id);

            if (opinion == null)
            {
                return null;
            }

            var result = await _opinionRepository.Delete(opinion);
            return result;
        }
    }
}
