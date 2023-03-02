namespace P01_StudentSystem.Data.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class ValidationConstants
    {
        public const int MaxLengthStudentName = 100;
        public const int LengthStudentPhoneNumber  = 10;

        public const int MaxLengthCourseName = 80;
        public const int MaxLengthCourseDescription = 1000;

        public const int MaxLengthResourceName = 50;
        public const int MaxLengthResourceUrl = 2048;

        public const int MaxLengthHomeworkContent = 2048;

    }
}
