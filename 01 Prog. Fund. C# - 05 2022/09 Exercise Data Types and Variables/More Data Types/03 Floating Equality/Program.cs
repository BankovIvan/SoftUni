using System;

namespace _03_Floating_Equality
{
    class Program
    {
        static void Main(string[] args)
        {
            double eps, nNumber1, nNumber2;

            eps = 0.000001;
            nNumber1 = double.Parse(Console.ReadLine());
            nNumber2 = double.Parse(Console.ReadLine());

            Console.WriteLine(Math.Abs(nNumber1 - nNumber2) <= eps);

        }
    }
}
