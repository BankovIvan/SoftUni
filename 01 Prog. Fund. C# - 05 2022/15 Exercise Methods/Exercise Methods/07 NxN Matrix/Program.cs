using System;

namespace _07_NxN_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;

            n = int.Parse(Console.ReadLine());

            PrintMatrixNxN(n);

        }

        private static void PrintMatrixNxN(int n)
        {
            int i, j;

            for(i = 0; i < n; i++)
            {
                for(j = 0; j < n; j++)
                {

                    Console.Write("{0} ", n);

                }

                Console.WriteLine();
            }

        }
    }
}
