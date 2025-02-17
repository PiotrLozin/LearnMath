using LearnMath.Application.OpenStreetMap;
using LearnMath.Application.OpenStreetMap.Queries;
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
        private readonly IMediator _mediator;
        public CreateUserCommandHandler(
            IUserRepository userRepository,
            IMediator mediator)
        {
            _userRepository = userRepository;
            _mediator = mediator;
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

            Coordinates requestedCoordinates;
            try
            {
                requestedCoordinates = await _mediator.Send(new GetCoordinatesQuery(request.UserRequest.Address.City, request.UserRequest.Address.PostCode));
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to retrieve coordinates from OpenStreetMap API.", ex);
            }

            if (requestedCoordinates.Equals(new Coordinates(0, 0)))
            {
                throw new ArgumentNullException("The specified address could not be found");
            }

            var userEntity = request.UserRequest.MapToDBUser(request.UserType, request.UserRequest.Address);
            userEntity.Address.Latitude = requestedCoordinates.Latitude;
            userEntity.Address.Longitude = requestedCoordinates.Longitude;

            var result = await _userRepository.Save(userEntity);

            return result;
        }
    }
}
