using LearnMath.Application.Addresses;
using LearnMath.Application.Students;
using LearnMath.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.Students.Responses
{
    public class GetAllStudentsReponse
    {
        public List<StudentDto> Students { get; set; }
        public GetAllStudentsReponse(List<StudentDto> students)
        {
            Students = students;
        }
    }
}
