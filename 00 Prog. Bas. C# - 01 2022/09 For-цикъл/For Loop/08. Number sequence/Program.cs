using System;

namespace _08._Number_sequence
{
    class Program
    {
        static void Main(string[] args)
        {

            int i = 0, nNumsIn = 0,  nNumsNum = 0, nNumsMax = int.MinValue, nNumsMin = int.MaxValue;

            nNumsNum = int.Parse(Console.ReadLine());

            for(i=0; i<nNumsNum; i++)
            {
                nNumsIn = int.Parse(Console.ReadLine());

                if(nNumsMax < nNumsIn)
                {
                    nNumsMax = nNumsIn;
                }

                if (nNumsMin > nNumsIn)
                {
                    nNumsMin = nNumsIn;
                }
            }

            Console.WriteLine("Max number: {0}", nNumsMax);
            Console.WriteLine("Min number: {0}", nNumsMin);

        }
    }
}
