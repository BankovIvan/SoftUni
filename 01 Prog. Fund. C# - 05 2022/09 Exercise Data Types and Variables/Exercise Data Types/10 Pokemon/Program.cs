using System;

namespace _10_Pokemon
{
    class Program
    {
        static void Main(string[] args)
        {
            long N, M, Y, nCount, n50Percent;

            N = long.Parse(Console.ReadLine());
            M = long.Parse(Console.ReadLine());
            Y = long.Parse(Console.ReadLine());
            nCount = 0;
            //n50Percent = 0;

            if((N & 1) == 0)
            {
                //Even - Exactly divisible by 2.
                n50Percent = N / 2;
            }
            else
            {
                n50Percent = N + 1;
            }

            while (N >= M)
            {
                nCount++;
                N -= M;

                if (N == n50Percent && Y != 0)
                {
                    N /= Y;
                }

            }

            Console.WriteLine(N);
            Console.WriteLine(nCount);

        }
    }
}
