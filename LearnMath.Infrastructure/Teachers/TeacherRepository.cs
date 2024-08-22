using LearnMath.Application.Teachers;
using LearnMath.Domain;
using LearnMath.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Infrastructure.Teachers
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly LearnMathContext _context;

        public TeacherRepository(LearnMathContext context)
        {
            _context = context;
        }

        public async Task<int> Delete(Teacher entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            _context.Teachers.Remove(entity);
            var result = await _context.SaveChangesAsync();
            return result;
        }

        public async Task<List<Teacher>> GetAll()
        {

            var teachers = await _context.Teachers.Include(x => x.Address).ToListAsync();
            
            return teachers;
        }

        public async Task<Teacher?> GetById(int id)
        {
            var teacher = await _context.Teachers.Include(x => x.Address).SingleOrDefaultAsync(x => x.Id == id);

            return teacher;
        }

        public async Task<int> Save(Teacher entity)
        {
            _context.Teachers.Add(entity);
            var result = await _context.SaveChangesAsync();
            return result;
        }

        public async Task<int> Update(Teacher entity)
        {
            var teacher = await _context.Teachers.FindAsync(entity.Id);
            if (teacher == null)
            {
                throw new ArgumentNullException();
            }

            var result = await _context.SaveChangesAsync();
            return result;
        }
    }
}
