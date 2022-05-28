using System;

namespace _12_Refactor_Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int nLastNumber = int.Parse(Console.ReadLine());

            for (int nCurrentNumber = 1; nCurrentNumber <= nLastNumber; nCurrentNumber++)
            {

                int nSum = 0;
                int nRemainder = nCurrentNumber;
                bool isSpecialNum = false;

                //nRemainder = nCurrentNumber;

                while (nRemainder > 0)
                {
                    nSum += nRemainder % 10;
                    nRemainder = nRemainder / 10;
                }

                isSpecialNum = (nSum == 5) || (nSum == 7) || (nSum == 11);

                Console.WriteLine("{0} -> {1}", nCurrentNumber, isSpecialNum);
                
                //nSum = 0;
                //nCurrentNumber = nRemainder;

            }

        }
    }
}
