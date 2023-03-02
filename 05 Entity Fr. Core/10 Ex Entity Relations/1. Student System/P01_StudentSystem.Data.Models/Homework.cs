namespace P01_StudentSystem.Data.Models
{
    using P01_StudentSystem.Data.Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Homework
    {
        public int HomeworkId { get; set; }

        public string Content { get; set; } = null!;

        public ContentTypeEnum ContentType { get; set; }

        public DateTime SubmissionTime { get; set; }

        public int StudentId { get; set; }
        public virtual Student Student { get; set; } = null!;

        public int CourseId { get; set; }
        public virtual Course Course { get; set; } = null!;

    }
}
