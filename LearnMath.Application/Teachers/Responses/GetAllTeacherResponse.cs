using LearnMath.Application.Addresses;
using LearnMath.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.Teachers.Responses
{
    public class GetAllTeacherResponse
    {
        public bool IsError { get; set; } = false;
        public List<string> Errors { get; set; }
        public List<TeacherDto> Teachers { get; set; }
        public GetAllTeacherResponse(List<TeacherDto> teachers)
        {
            Teachers = teachers;
        }
    }
}
