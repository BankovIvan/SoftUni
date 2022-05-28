using System;

namespace _04_Sum_of_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, nChars, nSum;

            nChars = int.Parse(Console.ReadLine());
            nSum = 0;

            for (i = 0; i < nChars; i++)
            {
                nSum += (int)char.Parse(Console.ReadLine());
            }

            Console.WriteLine("The sum equals: {0}", nSum);

        }
    }
}
