﻿namespace P01_StudentSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class StudentCourse
    {
        public int StudentId { get; set; }
        public virtual Student Student { get; set; } = null!;

        public int CourseId { get; set; }
        public virtual Course Course { get; set; } = null!;

    }
}
