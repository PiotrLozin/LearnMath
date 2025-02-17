using LearnMath.Application.OpenStreetMap.Queries;
using LearnMath.Application.OpenStreetMap;
using LearnMath.Application.Users;
using LearnMath.Application.Users.Commands;
using LearnMath.Application.Users.Requests.Extensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearnMath.Domain.Enums;

namespace LearnMath.Application.Users.Commands.Handlers
{
    public class EditUserCommandHandler : IRequestHandler<EditUserCommand, int?>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;

        public EditUserCommandHandler(
            IUserRepository userRepository,
            IMediator mediator)
        {
            _userRepository = userRepository;
            _mediator = mediator;
        }

        public async Task<int?> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            var teacher = await _userRepository.GetById(request.Id);

            if (teacher == null)
            {
                return null;
            }

            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (!Enum.IsDefined(typeof(Gender), request.EditUserRequest.Gender))
            {
                throw new ArgumentException($"Invalid gender value: {request.EditUserRequest.Gender}", nameof(request.EditUserRequest.Gender));
            }

            Coordinates requestedCoordinates;
            try
            {
                requestedCoordinates = await _mediator.Send(new GetCoordinatesQuery(request.EditUserRequest.Address.City, request.EditUserRequest.Address.PostCode));
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to retrieve coordinates from OpenStreetMap API.", ex);
            }

            if (requestedCoordinates.Equals(new Coordinates(0, 0)))
            {
                throw new ArgumentNullException("The specified address could not be found");
            }

            var editedTeacher = request.EditUserRequest.EditTeacher(teacher, requestedCoordinates);
            var result = await _userRepository.Update(editedTeacher);
            return result;

        }
    }
}
