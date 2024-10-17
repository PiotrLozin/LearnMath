using LearnMath.Domain;
using LearnMath.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.Users
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll(UserType userType);
        Task<User?> GetById(int id);
        Task<int> Save(User entity);
        Task<int> Delete(User entity);
        Task<int> Update(User entity);
    }
}
