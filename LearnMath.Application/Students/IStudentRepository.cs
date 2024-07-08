using LearnMath.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.Students
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAll();
        Task<int> Save(Student entity);
    }
}
