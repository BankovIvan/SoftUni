using System;

namespace _03_Passed_or_Failed
{
    class Program
    {
        static void Main(string[] args)
        {
            double dGrade;

            dGrade = double.Parse(Console.ReadLine());

            if (dGrade >= 3.0)
            {
                Console.WriteLine("Passed!");
            }
            else
            {
                Console.WriteLine("Failed!");
            }
        }
    }
}
