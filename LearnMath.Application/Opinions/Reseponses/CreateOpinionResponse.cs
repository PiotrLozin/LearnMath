using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.Opinions.Reseponses
{
    public class CreateOpinionResponse
    {
        public bool IsError { get; set; } = false;
        public List<string> Errors { get; set; }
        public bool IsSuccess { get; set; }
    }
}
