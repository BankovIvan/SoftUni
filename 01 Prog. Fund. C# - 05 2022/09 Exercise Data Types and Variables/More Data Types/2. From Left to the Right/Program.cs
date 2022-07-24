using System;
using System.Numerics;

namespace _2._From_Left_to_the_Right
{
    class Program
    {
        static void Main(string[] args)
        {
            string sData;
            long i, nLoop, nLeft, nRight, nRemainder, nSum;

            nLoop = int.Parse(Console.ReadLine());

            for(i = 0; i < nLoop; i++)
            {
                sData = Console.ReadLine();

                nLeft = long.Parse(sData.Split(" ")[0]);
                nRight = long.Parse(sData.Split(" ")[1]);

                if (nLeft < nRight)
                {
                    nLeft = nRight;
                }

                nRemainder = Math.Abs(nLeft);
                nSum = 0;

                for (; nRemainder > 0; nRemainder /= 10)
                {
                    nSum += nRemainder % 10;

                }

                Console.WriteLine(nSum);
            }



        }
    }
}
