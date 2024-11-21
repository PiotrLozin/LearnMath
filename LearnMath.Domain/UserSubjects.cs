using LearnMath.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Domain
{
    public class UserSubjects
    {
        [Key]
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public Subject Subject { get; set; }

    }
}
