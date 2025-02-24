﻿using LearnMath.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.Teachers.Dtos
{
    public class TeacherFilterDto
    {
        public Subject? Subject { get; set; } = null;
        public string? City { get; set; } = string.Empty;
        public string? PostalCode { get; set; } = string.Empty;
        public int Score { get; set; } = 0;
        public int Distance { get; set; } = 0;
    }
}
