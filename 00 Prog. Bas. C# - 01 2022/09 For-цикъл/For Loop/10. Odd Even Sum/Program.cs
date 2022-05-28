using System;

namespace _10._Odd_Even_Sum
{
    class Program
    {
        static void Main(string[] args)
        {

            int i = 0, nNumsIn = 0, nSumEven = 0, nSumOdd = 0, nDelta = 0;

            nNumsIn = int.Parse(Console.ReadLine());

            for(i=0; i<nNumsIn; i++)
            {
                if((i & 1) == 0)
                {
                    nSumEven += int.Parse(Console.ReadLine());
                }
                else
                {
                    nSumOdd += int.Parse(Console.ReadLine());
                }

            }

            nDelta = Math.Abs(nSumOdd - nSumEven);

            if (nDelta == 0)
            {
                Console.WriteLine("Yes");
                Console.WriteLine("Sum = {0}", nSumOdd);
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine("Diff = {0}", nDelta);
            }

        }
    }
}
