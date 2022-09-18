using System;
using System.Collections.Generic;

namespace _12_Cups_and_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {

            Queue<int> qCups = new Queue<int>(Array.ConvertAll(
                    Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries),
                    new Converter<string, int>(int.Parse)));
            Stack<int> stckBottles = new Stack<int>(Array.ConvertAll(
                    Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries),
                    new Converter<string, int>(int.Parse)));
            int nWastedWater = 0;
            int nCupWater = qCups.Peek();

            while(stckBottles.Count > 0)
            {
                nCupWater -= stckBottles.Pop();
                if (nCupWater <= 0)
                {
                    nWastedWater -= nCupWater;
                    qCups.Dequeue();
                    if (qCups.Count > 0)
                    {
                        nCupWater = qCups.Peek();
                    }
                    else
                    {
                        break;
                    }
                    
                }

            }

            if(qCups.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Cups: {0}", string.Join(' ', qCups.ToArray()));
                Console.WriteLine("Wasted litters of water: {0}", nWastedWater);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Bottles: {0}", string.Join(' ', stckBottles.ToArray()));
                Console.WriteLine("Wasted litters of water: {0}", nWastedWater);
                Console.ResetColor();
            }


        }
    }
}
