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
        private readonly IOpenStreetMapService _openStreetMapService;

        public GetTeachersByFilterQueryHandler(IUserRepository userRepository, IOpenStreetMapService openStreetMapService)
        {
            _userRepository = userRepository;
            _openStreetMapService = openStreetMapService;
        }

        public async Task<GetAllTeacherResponse> Handle(GetTeachersByFilterQuery request, CancellationToken cancellationToken)
        {
            var userQuery = _userRepository.GetUsers(UserType.Teacher);

            if (request.Distance == 0 && !string.IsNullOrEmpty(request.City))
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

            var teachers = await userQuery.ToListAsync();

            if (teachers.Count > 0 && request.Distance > 0 && !string.IsNullOrEmpty(request.City))
            {
                // Filtering locations by distance - It should be moved to the SQL in a future
                teachers = await GetUsersInRequestedDistance(teachers, request.City, request.PostalCode, request.Distance);
            }

            var teachersDto = teachers.Select(teacher =>
            {
                var dto = teacher.MapToTeacherDto();
                dto.Subjects = teacher.UserSubjects.Select(us => us.Subject).ToList();
                dto.Address = teacher.Address.MapToAddressDto();

                return dto;
            }).ToList();

            return new GetAllTeacherResponse(teachersDto);
        }

        private async Task<List<User>> GetUsersInRequestedDistance(
            List<User> teachers,
            string city,
            string postalCode,
            int distance)
        {
            Coordinates requestedCoordinates = await _openStreetMapService.GetCoordinates(city, postalCode);
            if (requestedCoordinates.Equals(new Coordinates(0, 0)))
            {
                throw new ArgumentNullException("The specified address could not be found");
            }
            const double EarthRadiusKm = 6371.0;

            teachers = (List<User>)teachers.Where(user =>
                user.Address.Latitude != 0 && user.Address.Longitude != 0 && // Pomijamy niepełne adresy
                (EarthRadiusKm *

                    Math.Acos(
                        Math.Cos(DegreeToRadian(requestedCoordinates.Latitude)) *
                        Math.Cos(DegreeToRadian(user.Address.Latitude)) *
                        Math.Cos(DegreeToRadian(user.Address.Longitude) - DegreeToRadian(requestedCoordinates.Longitude)) +
                        Math.Sin(DegreeToRadian(requestedCoordinates.Latitude)) *
                        Math.Sin(DegreeToRadian(user.Address.Latitude))
                    )) <= distance).ToList();

            return teachers;
        }

        private static double DegreeToRadian(double degree)
        {
            return degree * Math.PI / 180.0;
        }
    }
}
