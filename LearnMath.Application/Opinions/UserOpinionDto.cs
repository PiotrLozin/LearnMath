﻿using LearnMath.Application.Students;
using LearnMath.Application.Teachers;
using LearnMath.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.Opinions
{
    public class UserOpinionDto
    {
        public UserOpinionDto(
            int id,
            int score,
            string description,
            string createdByUser
            )
        {
            Id = id;
            Score = score;
            Description = description;
            CreatedByUser = createdByUser;
        }
        public int Id { get; set; }
        public int Score { get; set; }
        public string Description { get; set; }
        public string CreatedByUser { get; set; }
        public TeacherDto Teacher { get; set; }
    }
}
