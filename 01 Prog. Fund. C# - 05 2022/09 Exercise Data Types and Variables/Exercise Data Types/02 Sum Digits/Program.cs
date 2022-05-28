using System;

namespace _02_Sum_Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            int nRemainder, nSum;

            nRemainder = int.Parse(Console.ReadLine());
            nSum = 0;

            for (; nRemainder > 0; nRemainder /= 10)
            {
                nSum += nRemainder % 10;
   
            }

            Console.WriteLine(nSum);

        }
    }
}
