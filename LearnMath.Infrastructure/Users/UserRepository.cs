using LearnMath.Application.Teachers;
using LearnMath.Application.Users;
using LearnMath.Domain;
using LearnMath.Domain.Enums;
using LearnMath.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Infrastructure.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly LearnMathContext _context;

        public UserRepository(LearnMathContext context)
        {
            _context = context;
        }

        public async Task<int> Delete(User entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            _context.Users.Remove(entity);
            var result = await _context.SaveChangesAsync();
            return result;
        }

        public async Task<List<User>> GetAll(UserType userType)
        {
            var users = await _context.Users
                .Include(x => x.Address)
                .Include(x => x.Opinions)
                .Where(u => u.UserType == userType).ToListAsync();

            return users;
        }

        public IQueryable<User> GetUsers(UserType userType)
        {
            var users = _context.Users
                .Include(x => x.Address)
                .Include(x => x.Opinions)
                .Where(u => u.UserType == userType);

            return users;
        }

        public async Task<User?> GetById(int id)
        {
            var user = await _context.Users.Include(x => x.Address).SingleOrDefaultAsync(x => x.Id == id);

            return user;
        }

        public async Task<int> Save(User entity)
        {
            _context.Users.Add(entity);
            var result = await _context.SaveChangesAsync();
            return result;
        }

        public async Task<int> Update(User entity)
        {
            var user = await _context.Users.FindAsync(entity.Id);
            if (user == null)
            {
                throw new ArgumentNullException();
            }

            var result = await _context.SaveChangesAsync();
            return result;
        }
    }
}
