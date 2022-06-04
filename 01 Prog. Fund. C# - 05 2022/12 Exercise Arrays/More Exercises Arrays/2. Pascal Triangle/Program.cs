using System;

namespace _2._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, j, nLines, nElements;
            int[,] arrTriangle;

            nLines = int.Parse(Console.ReadLine());

            if(nLines <= 0)
            {
                return;
            }

            nElements = nLines + 1;

            arrTriangle = new int[nElements, nElements];

            // Colon 1 is empty!
            // Row 1 contains 0 1 0 0 0 ...
            // Row 2 contains 0 1 1 0 0 ...
            // Row 3 contains 0 1 2 1 0 ...

            arrTriangle[0, 1] = 1;

            for (i = 1; i < nLines; i++)
            {
                for (j = 1; j < nElements; j++)
                {
                    arrTriangle[i, j] = arrTriangle[i - 1, j - 1] + arrTriangle[i - 1, j];

                    if (arrTriangle[i, j] == 0)
                    {
                        break;
                    }

                }

            }

            for (i = 0; i < nLines; i++)
            {
                for (j = 1; j < nElements && arrTriangle[i, j] > 0; j++)
                {
                    Console.Write("{0} ", arrTriangle[i, j]);

                }

                Console.WriteLine();
            }

        }
    }
}
