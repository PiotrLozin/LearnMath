using LearnMath.Application.OpenStreetMap;
using LearnMath.Application.Teachers.MappingProfiles;
using LearnMath.Application.Teachers.Responses;
using LearnMath.Application.Users;
using LearnMath.Application.Users.MappingProfiles;
using LearnMath.Domain;
using LearnMath.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LearnMath.Application.Teachers.Queries.Handlers
{
    public class GetTeachersByFilterQueryHandler : IRequestHandler<GetTeachersByFilterQuery, GetAllTeacherResponse>
    {
        private readonly IUserRepository _userRepository;

        public GetTeachersByFilterQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GetAllTeacherResponse> Handle(GetTeachersByFilterQuery request, CancellationToken cancellationToken)
        {
            var userQuery = _userRepository.GetUsers(UserType.Teacher);

            if (request.Distance > 0 && !string.IsNullOrEmpty(request.City))
            {
                Coordinates requestedCoordinates = await OsmExtension.GetCoordinates(request.City);
            }
            else if (request.Distance == 0 && !string.IsNullOrEmpty(request.City))
            {
                userQuery = userQuery.Where(user => EF.Functions.Like(user.Address.City, $"%{request.City}%"));
            }

            if (request.Subject.HasValue)
            {
                userQuery = userQuery.Where(user => user.UserSubjects.Any(us => us.Subject == request.Subject.Value));
            }

            if (request.Score > 0 && request.Score <= 5)
            {
                userQuery = userQuery;
            }

            if (request.Score > 0)
            {
                userQuery = userQuery;
            }

            var teachers = await userQuery.ToListAsync();
            var teachersDto = teachers.Select(teacher =>
            {
                var dto = teacher.MapToTeacherDto();
                dto.Subjects = teacher.UserSubjects.Select(us => us.Subject).ToList();
                dto.Address = teacher.Address.MapToAddressDto();

                return dto;
            }).ToList();

            return new GetAllTeacherResponse(teachersDto);
        }
    }
}
