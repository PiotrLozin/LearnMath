using LearnMath.Domain;
using LearnMath.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.Opinions
{
    public interface IOpinionRepository
    {
        Task<List<UserOpinion>> GetAll();
        Task<int> Save(UserOpinion userOpinion);
    }
}
