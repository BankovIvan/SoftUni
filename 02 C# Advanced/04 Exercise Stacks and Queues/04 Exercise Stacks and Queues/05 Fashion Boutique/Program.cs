using System;
using System.Collections.Generic;

namespace _05_Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stckBox = new Stack<int>(Array.ConvertAll(
                    Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries),
                    new Converter<string, int>(int.Parse))
                                    );

            int nSum, nRacks, nValue, nCapacity = int.Parse(Console.ReadLine());

            nSum = 0;
            nRacks = 1;
            while(stckBox.Count > 0)
            {
                nValue = stckBox.Pop();
                nSum += nValue;
                if(nSum > nCapacity)
                {
                    nSum = nValue;
                    nRacks++;
                }

            }

            Console.WriteLine(nRacks);

        }
    }
}
