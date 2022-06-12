using System;

namespace _04_Printing_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int nNum, i;

            nNum = int.Parse(Console.ReadLine());

            for(i = 1; i <= nNum; i++)
            {
                MyPrintRow(1, i);
            }

            for (i = nNum - 1; i > 0; i--)
            {
                MyPrintRow(1, i);
            }

        }

        private static void MyPrintRow(int nFirst, int nLast)
        {
            int i;

            for(i = nFirst; i <= nLast; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}
