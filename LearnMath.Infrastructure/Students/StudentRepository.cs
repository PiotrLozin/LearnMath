using LearnMath.Application.Students;
using LearnMath.Application.Teachers;
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
    public class StudentRepository : IUserRepository
    {
        private readonly LearnMathContext _context;

        public StudentRepository(LearnMathContext context)
        {
            _context = context;
        }

        public Task<int> Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetAll()
        {

            var users = await _context.Users.Include(x => x.Address).ToListAsync();

            return users;
        }

        public Task<User?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Save(User entity)
        {
            _context.Users.Add(entity);
            var result = await _context.SaveChangesAsync();
            return result;
        }

        public Task<int> Update(User entity)
        {
            throw new NotImplementedException();
        }

        Task<List<User>> IUserRepository.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
