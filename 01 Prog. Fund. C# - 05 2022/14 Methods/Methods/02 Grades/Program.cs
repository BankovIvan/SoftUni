using System;

namespace _02_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            double dGrade;

            dGrade = double.Parse(Console.ReadLine());

            PrintGrade(dGrade);

        }

        private static void PrintGrade(double dGrade)
        {
            if(dGrade >= 2.00 && dGrade < 3.00)
            {
                Console.WriteLine("Fail");
            }
            else if (dGrade >= 3.00 && dGrade < 3.50)
            {
                Console.WriteLine("Poor");
            }
            else if (dGrade >= 3.50 && dGrade < 4.50)
            {
                Console.WriteLine("Good");
            }
            else if (dGrade >= 4.50 && dGrade < 5.50)
            {
                Console.WriteLine("Very good");
            }
            else if (dGrade >= 5.50)
            {
                Console.WriteLine("Excellent");
            }
        }
    }
}
