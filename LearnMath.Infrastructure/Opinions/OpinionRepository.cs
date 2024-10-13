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

        public async Task<List<UserOpinion>> GetAll()
        {
            var opinions = await _context.Opinions
                .Include(x => x.Teacher)
                .Include(x => x.CreatedByUser)
                .Include(x => x.Teacher.Address)
                .Include(x => x.CreatedByUser.Address)
                .ToListAsync();

            return opinions;
        }

        public async Task<int> Save(UserOpinion userOpinion)
        {
            _context.Opinions.Add(userOpinion);
            var result = await _context.SaveChangesAsync();
            return result;
        }
    }
}
