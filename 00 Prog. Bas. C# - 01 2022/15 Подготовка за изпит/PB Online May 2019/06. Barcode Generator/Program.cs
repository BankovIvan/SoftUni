using System;

namespace _06._Barcode_Generator
{
    class Program
    {
        static void Main(string[] args)
        {

            int i = 0, j = 0, nMin = 0, nMax = 0, nDivMin = 0, nDivMax = 0, nDivNum = 0, nDivCheck;

            nMin = int.Parse(Console.ReadLine());
            nMax = int.Parse(Console.ReadLine());

            for(i = nMin; i <= nMax; i++)
            {

                j = i;
                nDivMin = nMin;
                nDivMax = nMax;

                while (j > 0)
                {

                    nDivNum = j % 10;

                    if (((nDivNum & 1) == 0) || (nDivNum < nDivMin % 10) || (nDivNum > nDivMax % 10))
                    {

                        break;

                    }

                    j = j / 10;
                    nDivMin = nDivMin / 10;
                    nDivMax = nDivMax / 10;
                }

                if(j == 0)
                {
                    Console.Write(i + " ");
                }

            }

        }
    }
}
