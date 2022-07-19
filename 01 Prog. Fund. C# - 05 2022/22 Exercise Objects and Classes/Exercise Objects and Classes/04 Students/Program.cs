using System;
using System.Collections.Generic;
using System.Numerics;
//using System.Linq;

namespace _04_Students
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }

        public Student()
        {
        }

        public Student(string FirstName, string LastName, double Grade)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Grade = Grade;
        }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName + ": " + string.Format("{0:F2}", this.Grade);
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            int i, nRepeat;
            List<Student> lstStudents = new List<Student>();
            string[] arrInput;

            nRepeat = int.Parse(Console.ReadLine());

            for (i = 0; i < nRepeat; i++)
            {
                arrInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                lstStudents.Add(new Student(arrInput[0], arrInput[1], double.Parse(arrInput[2])));

            }

            lstStudents.Sort((x, y) => y.Grade.CompareTo(x.Grade));

            lstStudents.ForEach(x => Console.WriteLine(x));

        }
    }
}
