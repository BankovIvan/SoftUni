using System;

namespace _06_Strong_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, j, nNumber, nData, nDigit, nFactN, nFactSum;

            nData = int.Parse(Console.ReadLine());
            nNumber = nData;
            nDigit = 0;
            nFactN = 0;
            nFactSum = 0;

            do
            {

                nDigit = nNumber % 10;
                nNumber = nNumber / 10;

                nFactN = 1;
                for (j = 2; j <= nDigit; j++)
                {
                    nFactN *= j;

                }

                nFactSum += nFactN;

            } while (nNumber > 0);

            if(nFactSum == nData)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }

        }
    }
}
