using System;

namespace _09._Left_and_Right_Sum
{
    class Program
    {
        static void Main(string[] args)
        {

            int i = 0, nNumsNumIn = 0, nNumsNumHalf = 0, nNumsLeft = 0, nNumsRight = 0, nNumsDelta = 0;

            nNumsNumHalf = int.Parse(Console.ReadLine());
            nNumsNumIn = nNumsNumHalf * 2;

            for(i=0; i<nNumsNumIn; i++)
            {
                if(i < nNumsNumHalf)
                {
                    nNumsLeft += int.Parse(Console.ReadLine());
                }
                else
                {
                    nNumsRight += int.Parse(Console.ReadLine());
                }
            }

            nNumsDelta = Math.Abs(nNumsLeft - nNumsRight);

            if(nNumsDelta == 0)
            {
                Console.WriteLine("Yes, sum = {0}", nNumsLeft);
            }
            else
            {
                Console.WriteLine("No, diff = {0}", nNumsDelta);
            }

        }
    }
}
