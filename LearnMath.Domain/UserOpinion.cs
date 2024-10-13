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

        public int CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }

        public int TeacherId { get; set; }
        public User Teacher { get; set; }
    }
}
