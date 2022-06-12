using System;

namespace _01_Smallest_of_Three_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int nNum1, nNum2, nNum3;

            nNum1 = int.Parse(Console.ReadLine());
            nNum2 = int.Parse(Console.ReadLine());
            nNum3 = int.Parse(Console.ReadLine());

            Console.WriteLine(MySmallestOfThreeNumbers(nNum1, nNum2, nNum3));

        }

        private static int MySmallestOfThreeNumbers(int nNum1, int nNum2, int nNum3)
        {
            int nRet = nNum1;

            if(nRet > nNum2)
            {
                nRet = nNum2;
            }

            if (nRet > nNum3)
            {
                nRet = nNum3;
            }

            return nRet;

        }
    }
}
