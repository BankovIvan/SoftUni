using System;

namespace _03._Histogram
{
    class Program
    {
        static void Main(string[] args)
        {

            int i = 0, nNums = 0, nNumIn=0, nP1 = 0, nP2 = 0, nP3 = 0, nP4 = 0, nP5 = 0, nPSum=0;

            nNums = int.Parse(Console.ReadLine());

            for(i=0; i<nNums; i++)
            {

                nNumIn = int.Parse(Console.ReadLine());

                if(nNumIn < 200)
                {
                    nP1++;
                }
                else if (nNumIn < 400)
                {
                    nP2++;
                }
                else if (nNumIn < 600)
                {
                    nP3++;
                }
                else if (nNumIn < 800)
                {
                    nP4++;
                }
                else
                {
                    nP5++;
                }

            }

            nPSum = nP1 + nP2 + nP3 + nP4 + nP5;

            Console.WriteLine("{0:F2}%", 100.0 * (double)nP1 / (double)nPSum);
            Console.WriteLine("{0:F2}%", 100.0 * (double)nP2 / (double)nPSum);
            Console.WriteLine("{0:F2}%", 100.0 * (double)nP3 / (double)nPSum);
            Console.WriteLine("{0:F2}%", 100.0 * (double)nP4 / (double)nPSum);
            Console.WriteLine("{0:F2}%", 100.0 * (double)nP5 / (double)nPSum);

        }
    }
}
