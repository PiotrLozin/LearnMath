using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.Opinions.Requests
{
    public class CreateOpinionRequest
    {
        public int Score { get; set; }
        public string Description { get; set; }
        public int CreatorId { get; set; }
        public int TeacherId { get; set; }
    }
}
