using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.Teachers.Dtos
{
    public class TeacherFilterDto
    {
        public string? Subject { get; set; } = string.Empty;
        public string? City { get; set; } = string.Empty;
        public int Score { get; set; }
        public int Distance { get; set; }
    }
}
