using LearnMath.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.Teachers
{
    public interface ITeacherRepository
    {
        Task<List<Teacher>> GetAll();
        Task<Teacher?> GetById(int id);
        Task<int> Save(Teacher entity);
        Task<int> Delete(Teacher entity);
        Task<int> Update(Teacher entity);
    }
}
