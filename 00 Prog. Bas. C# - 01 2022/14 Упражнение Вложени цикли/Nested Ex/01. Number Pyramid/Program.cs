using System;

namespace _01._Number_Pyramid
{
    class Program
    {
        static void Main(string[] args)
        {

            int nMax = 0, nCount = 0, i = 0, j = 0;

            nMax = int.Parse(Console.ReadLine());

            for(i = 1; i <= nMax; i++)
            {
                for(j = 1; j <= i; j++)
                {

                    nCount++;

                    if (nCount > nMax)
                    {
                        Console.WriteLine();
                        return;
                    }

                    Console.Write(nCount + " ");

                }

                Console.WriteLine();

            }

        }
    }
}
