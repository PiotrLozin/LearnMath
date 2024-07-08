using LearnMath.Application.Students;
using LearnMath.Domain;
using LearnMath.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Infrastructure.Students
{
    public class StudentRepository : IStudentRepository
    {
        private readonly LearnMathContext _context;

        public StudentRepository(LearnMathContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> GetAll()
        {
            var students = await _context.Students.Include(x => x.Address).ToListAsync();

            return students;
        }

        public async Task<int> Save(Student entity)
        {
            _context.Students.Add(entity);
            var result = await _context.SaveChangesAsync();
            return result;
        }
    }
}
