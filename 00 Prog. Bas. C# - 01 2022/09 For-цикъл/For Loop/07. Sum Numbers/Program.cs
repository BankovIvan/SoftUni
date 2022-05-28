using System;

namespace _07._Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0, nNumsNum = 0, nNumsSum = 0;

            nNumsNum = int.Parse(Console.ReadLine());

            for(i = 0; i < nNumsNum; i++)
            {
                nNumsSum += int.Parse(Console.ReadLine());
            }

            Console.WriteLine(nNumsSum);

        }
    }
}
