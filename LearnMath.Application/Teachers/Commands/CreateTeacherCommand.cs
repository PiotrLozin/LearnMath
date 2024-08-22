using LearnMath.Application.Teachers.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.Teachers.Commands
{
    public class CreateTeacherCommand : IRequest<int>
    {
        public CreateTeacherRequest TeacherRequest { get; set; }

        public CreateTeacherCommand(CreateTeacherRequest teacherRequest)
        {
            TeacherRequest = teacherRequest;
        }
    }
}
