using System;

namespace _01._ExcellentResult
{
    class Program
    {
        static void Main(string[] args)
        {

            double grade;

            grade = double.Parse(Console.ReadLine());

            if(grade >= 5.5)
            {
                Console.WriteLine("Excellent!");
            }
        }
    }
}
