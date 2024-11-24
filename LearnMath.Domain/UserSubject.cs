using LearnMath.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Domain
{
    public class UserSubject
    {
        [Key]
        public int Id { get; set; }
        public int TeacherId { get; set; }

        [ForeignKey(nameof(TeacherId))]
        public virtual User Teacher { get; set; }
        public Subject Subject { get; set; }

    }
}
