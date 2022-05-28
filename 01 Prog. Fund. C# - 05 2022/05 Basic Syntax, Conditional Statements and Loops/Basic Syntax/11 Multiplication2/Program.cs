using System;

namespace _10_Multiplication
{
    class Program
    {
        static void Main(string[] args)
        {
            int nNumber, nMultiplier;

            nNumber = int.Parse(Console.ReadLine());
            nMultiplier = int.Parse(Console.ReadLine());

            do
            {
                Console.WriteLine("{0} X {1} = {2}", nNumber, nMultiplier, nNumber * nMultiplier);
                nMultiplier++;

            } while (nMultiplier <= 10);
        }
    }
}
