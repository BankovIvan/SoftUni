using System;

namespace _01_Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int nLines, nSum;
            int[] arrVagonPeoples;

            nLines = int.Parse(Console.ReadLine());

            arrVagonPeoples = new int[nLines];
            nSum = 0;

            for(int i = 0; i < nLines; i++)
            {
                arrVagonPeoples[i] = int.Parse(Console.ReadLine());
                nSum += arrVagonPeoples[i];
            }

            Console.WriteLine(string.Join(' ', arrVagonPeoples));
            Console.WriteLine(nSum);

        }
    }
}
