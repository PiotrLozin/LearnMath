using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Domain
{
    public class UserOpinion
    {
        [Key]
        public int Id { get; set; }
        public int Score { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
    }

}
