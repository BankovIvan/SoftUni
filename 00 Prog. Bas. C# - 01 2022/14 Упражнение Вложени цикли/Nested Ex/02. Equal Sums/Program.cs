using System;

namespace _02._Equal_Sums
{
    class Program
    {
        static void Main(string[] args)
        {

            int i = 0, j = 0, nLow = 0, nHigh = 0, nSum = 0, nRem = 0, nValue = 0;
            bool bEven = false;

            nLow = int.Parse(Console.ReadLine());
            nHigh = int.Parse(Console.ReadLine());

            for (i = nLow; i<= nHigh; i++)
            {

                nValue = i;
                bEven = false;
                nSum = 0;

                while (nValue > 0)
                {
                    nRem = nValue % 10;

                    if(bEven == false)
                    {
                        nSum += nRem;
                    }
                    else
                    {
                        nSum -= nRem;
                    }

                    nValue = nValue / 10;
                    bEven = !(bEven);

                }

                if(nSum == 0)
                {
                    Console.Write(i + " ");
                }

            }

            Console.WriteLine();

        }
    }
}
