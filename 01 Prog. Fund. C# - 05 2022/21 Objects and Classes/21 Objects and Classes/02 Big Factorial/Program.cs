using System;
using System.Numerics;

namespace _02_Big_Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, nNumber;
            BigInteger nFactorial = 1;

            nNumber = int.Parse(Console.ReadLine());

            for (i = 2; i <= nNumber; i++)
            {
                nFactorial = nFactorial * i;
            }

            Console.WriteLine(nFactorial);

        }
    }
}