﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsProject.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Gender { get; set; } = "";
        public int Age { get; set; }
        public string Major { get; set; } = "";
    }
}
