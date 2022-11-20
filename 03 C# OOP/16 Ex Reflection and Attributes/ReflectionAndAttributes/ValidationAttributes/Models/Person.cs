namespace ValidationAttributes.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using ValidationAttributes.Models.Contracts;
    using ValidationAttributes.Utilities;

    public class Person : IPerson
    {
        private string fullName;
        private int age;

        private const int MIN_AGE = 12;
        private const int MAX_AGE = 90;

        [MyRequired]
        public string FullName
        {
            get { return fullName; }
            private set
            {
                fullName = value;
            }
        }

        [MyRequired]
        [MyRange(MIN_AGE, MAX_AGE)]
        public int Age
        {
            get { return age; }
            private set
            {
                age = value;
            }
        }

        public Person(string fullName, int age)
        {
            FullName = fullName;
            Age = age;
        }
    }
}
