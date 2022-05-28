using System;

namespace _03._Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            int nMax = 0, nSum = 0;

            nMax = int.Parse(Console.ReadLine());

            while (nSum < nMax)
            {
                nSum += int.Parse(Console.ReadLine());
            }


            Console.WriteLine(nSum);
        }
    }
}
