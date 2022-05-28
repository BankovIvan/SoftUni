using System;

namespace _04._Sum_of_Two
{
    class Program
    {
        static void Main(string[] args)
        {

            int nLow = 0, nHigh = 0, nMagic = 0, nCount = 0, i = 0, j = 0;

            nLow = int.Parse(Console.ReadLine());
            nHigh = int.Parse(Console.ReadLine());
            nMagic = int.Parse(Console.ReadLine());

            for(i = nLow; i <= nHigh; i++)
            {
                for(j = nLow; j <= nHigh; j++)
                {
                    nCount++;

                    if((i + j) == nMagic)
                    {
                        Console.WriteLine("Combination N:{0} ({1} + {2} = {3})", nCount, i, j, nMagic);
                        return;

                    }

                }
            }

            Console.WriteLine("{0} combinations - neither equals {1}", nCount, nMagic);

        }
    }
}
