using LearnMath.Application.Opinions;
using LearnMath.Domain;
using LearnMath.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Infrastructure.Opinions
{
    public class OpinionRepository : IOpinionRepository
    {
        private readonly LearnMathContext _context;

        public OpinionRepository(LearnMathContext context)
        {
            _context = context;
        }

        public async Task<int> Delete(UserOpinion userOpinion)
        {
            if (userOpinion == null)
            {
                throw new ArgumentNullException();
            }

            _context.Opinions.Remove(userOpinion);
            var result = await _context.SaveChangesAsync();
            return result;
        }

        public async Task<List<UserOpinion>> GetAll()
        {
            var opinions = await _context.Opinions
                .Include(x => x.Teacher)
                .Include(x => x.Teacher.Address)
                .ToListAsync();

            return opinions;
        }

        public async Task<UserOpinion?> GetById(int id)
        {
            var opinion = await _context.Opinions
                .Include(x => x.Teacher)
                .Include(x => x.Teacher.Address)
                .SingleOrDefaultAsync(x => x.Id == id);

            return opinion;
        }

        public async Task<List<UserOpinion>> GetAllByTeacherId(int teacherId)
        {
            var opinions = await _context.Opinions
                .Include(x => x.Teacher)
                .Include(x => x.Teacher.Address)
                .Where(x => x.TeacherId == teacherId)
                .ToListAsync();

            return opinions;
        }

        public async Task<int> Save(UserOpinion userOpinion)
        {
            _context.Opinions.Add(userOpinion);
            var result = await _context.SaveChangesAsync();
            return result;
        }

        public async Task<int> Update(UserOpinion userOpinion)
        {
            var opinion = await _context.Opinions.FindAsync(userOpinion.Id);
            if (opinion == null)
            {
                throw new ArgumentNullException();
            }

            var result = await _context.SaveChangesAsync();
            return result;
        }
    }
}
