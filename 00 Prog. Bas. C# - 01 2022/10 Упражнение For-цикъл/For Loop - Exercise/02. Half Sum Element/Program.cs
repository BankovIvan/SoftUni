using System;

namespace _02._Half_Sum_Element
{
    class Program
    {
        static void Main(string[] args)
        {

            int i = 0, nNumsIn = 0, nNumsNum=0, nNumsMax=int.MinValue, nNumsSum=0, nNumsTotal=0;

            nNumsNum = int.Parse(Console.ReadLine());

            for(i=0; i< nNumsNum; i++)
            {
                nNumsIn = int.Parse(Console.ReadLine());

                if(nNumsIn > nNumsMax)
                {
                    nNumsMax = nNumsIn;
                }

                nNumsTotal += nNumsIn;

            }

            nNumsSum = nNumsTotal - nNumsMax;

            if (nNumsSum == nNumsMax)
            {
                Console.WriteLine("Yes");
                Console.WriteLine("Sum = {0}", nNumsSum);
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine("Diff = {0}", Math.Abs(nNumsSum - nNumsMax));
            }

        }
    }
}
