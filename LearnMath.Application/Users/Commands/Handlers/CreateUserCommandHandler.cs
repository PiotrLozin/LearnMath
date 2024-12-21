using LearnMath.Application.OpenStreetMap;
using LearnMath.Application.Teachers;
using LearnMath.Application.Users.Requests.Extensions;
using LearnMath.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.Users.Commands.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        private readonly IOpenStreetMapService _openStreetMapService;
        public CreateUserCommandHandler(IUserRepository userRepository, IOpenStreetMapService openStreetMapService)
        {
            _userRepository = userRepository;
            _openStreetMapService = openStreetMapService;
        }
        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (!Enum.IsDefined(typeof(Gender), request.UserRequest.Gender))
            {
                throw new ArgumentException($"Invalid gender value: {request.UserRequest.Gender}", nameof(request.UserRequest.Gender));
            }

            if (request.UserRequest.Subjects == null || !request.UserRequest.Subjects.All(s => Enum.IsDefined(typeof(Subject), s)))
            {
                throw new ArgumentException("Invalid subjects in the list.", nameof(request.UserRequest.Subjects));
            }

            var userCoordinates = await _openStreetMapService.GetCoordinates(request.UserRequest.Address.City, request.UserRequest.Address.PostCode);
            request.UserRequest.Address.Coordinates = userCoordinates;

            var userEntity = request.UserRequest.MapToDBUser(request.UserType, request.UserRequest.Address);

            var result = await _userRepository.Save(userEntity);

            return result;
        }
    }
}
