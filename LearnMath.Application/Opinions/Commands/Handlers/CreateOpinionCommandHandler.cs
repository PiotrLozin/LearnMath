using LearnMath.Application.Opinions.Reseponses;
using LearnMath.Application.Users;
using LearnMath.Domain;
using LearnMath.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.Opinions.Commands.Handlers
{
    public class CreateOpinionCommandHandler : IRequestHandler<CreateOpinionCommand, CreateOpinionResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IOpinionRepository _opinionRepository;

        public CreateOpinionCommandHandler(IUserRepository userRepository, IOpinionRepository opinionRepository)
        {
            _userRepository = userRepository;
            _opinionRepository = opinionRepository;

        }
        public async Task<CreateOpinionResponse> Handle(CreateOpinionCommand request, CancellationToken cancellationToken)
        {
            var student = await _userRepository.GetById(request.OpinionRequest.CreatorId);

            if (student == null || student.UserType != UserType.Student)
            {
                return new CreateOpinionResponse 
                { 
                    IsError = true,
                    Errors = new List<string>()
                    {
                        "Student not found."
                    }
                };
            }

            var teacher = await _userRepository.GetById(request.OpinionRequest.TeacherId);

            if (teacher == null || teacher.UserType != UserType.Teacher)
            {
                return new CreateOpinionResponse
                {
                    IsError = true,
                    Errors = new List<string>()
                    {
                        "Teacher not found."
                    }
                };
            }

            var opinion = new UserOpinion
            {
                CreatedByUser = student,
                Teacher = teacher,
                Score = request.OpinionRequest.Score,
                Description = request.OpinionRequest.Description
            };

            var result = await _opinionRepository.Save(opinion);

            return new CreateOpinionResponse
            {
                IsSuccess = true,
            };
        }
    }
}
