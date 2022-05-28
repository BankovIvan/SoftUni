using System;

namespace _02_Passed
{
    class Program
    {
        static void Main(string[] args)
        {

            float fGrade;

            fGrade = float.Parse(Console.ReadLine());

            if (fGrade >= 3.0)
            {
                Console.WriteLine("Passed!");
            }
        }
    }
}
