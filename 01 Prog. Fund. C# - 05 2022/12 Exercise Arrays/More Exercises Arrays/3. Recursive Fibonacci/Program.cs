using System;

namespace _3._Recursive_Fibonacci
{
    class Program
    {

        //static long GetFibonacci(long n, int nDepth);

        static void Main(string[] args)
        {
            int nMaxDepth;

            nMaxDepth = int.Parse(Console.ReadLine());

            Console.WriteLine(GetFibonacci(1, 1, 3, nMaxDepth));

        }

        static long GetFibonacci(long lnNumber1, long lnNumber2, int lnCurrentDepth, int lnMaxDepth)
        {

            long nRet = 1;

            if (lnMaxDepth <= 2)
            {
                return nRet;
            }

            if (lnCurrentDepth > lnMaxDepth)
            {
                return lnNumber2;
            }

            //nRet = lnNumber1 + lnNumber2;
            lnCurrentDepth++;
            nRet = GetFibonacci(lnNumber2, lnNumber1 + lnNumber2, lnCurrentDepth, lnMaxDepth);

            return nRet;
        }
    }
}
