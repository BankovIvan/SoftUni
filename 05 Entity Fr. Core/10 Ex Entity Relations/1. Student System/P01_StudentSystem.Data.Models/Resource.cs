namespace P01_StudentSystem.Data.Models
{
    using P01_StudentSystem.Data.Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Resource
    {
        public int ResourceId { get; set; }

        public string Name { get; set; } = null!;

        public string Url { get; set; } = null!;

        public ResourceTypeEnum ResourceType { get; set; }

        public int CourseId { get; set; }
        public virtual Course Course { get; set; } = null!;

    }
}
