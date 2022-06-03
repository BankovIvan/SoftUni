using System;

namespace _03_Zig_Zag_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int nLines;
            int[] arrZig, arrZag;
            string[] arrLine = new string[2];
            bool bSwap;

            nLines = int.Parse(Console.ReadLine());

            arrZig = new int[nLines];
            arrZag = new int[nLines];
            bSwap = false;

            for(int i = 0; i < nLines; i++)
            {
                arrLine = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (bSwap == false)
                {
                    arrZig[i] = int.Parse(arrLine[0]);
                    arrZag[i] = int.Parse(arrLine[1]);
                }
                else
                {
                    arrZig[i] = int.Parse(arrLine[1]);
                    arrZag[i] = int.Parse(arrLine[0]);
                }

                bSwap = !bSwap;

            }

            Console.WriteLine(string.Join(' ', arrZig));
            Console.WriteLine(string.Join(' ', arrZag));

        }
    }
}
