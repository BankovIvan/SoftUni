using System;

namespace First_Steps_In_Programming
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            double usd;
            double bgn;

            usd = double.Parse(Console.ReadLine());

            bgn = usd * 1.79549;

            Console.WriteLine(bgn);

        }
    }
}
