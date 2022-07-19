using System;
using System.Collections.Generic;
using System.Numerics;

namespace _04_Students
{

    class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string City { get; set; }

    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] arrInput;
            List<Student> lstStudents = new List<Student>();
            Student objNewStudent;
            string sHomeTown;

            arrInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (arrInput[0] != "end")
            {

                objNewStudent = new Student()
                {
                    FirstName = arrInput[0],
                    LastName = arrInput[1],
                    Age = int.Parse(arrInput[2]),
                    City = arrInput[3]
                };

                lstStudents.Add(objNewStudent);

                arrInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            sHomeTown = Console.ReadLine();

            foreach (Student objNextStudent in lstStudents)
            {
                if (objNextStudent.City == sHomeTown)
                {
                    Console.WriteLine("{0} {1} is {2} years old.",
                                        objNextStudent.FirstName, objNextStudent.LastName, objNextStudent.Age);
                }
            }

        }
    }
}
