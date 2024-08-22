using LearnMath.Application.Teachers.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.Teachers.Commands
{
    public class EditTeacherCommand : IRequest<int?>
    {
        public EditTeacherRequest EditTeacherRequest { get; set; }
        public int Id { get; set; }
        public EditTeacherCommand(EditTeacherRequest editTeacherRequest, int id)
        {
            EditTeacherRequest = editTeacherRequest;
            Id = id;
        }
    }
}
