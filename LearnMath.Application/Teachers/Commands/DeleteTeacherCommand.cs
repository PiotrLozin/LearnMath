using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.Teachers.Commands
{
    public class DeleteTeacherCommand : IRequest<int?>
    {
        public int Id { get; set; }
        public DeleteTeacherCommand(int id)
        {
            Id = id;
        }
    }
}
