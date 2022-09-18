using System;
using System.Collections.Generic;

namespace _04_Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, nMaxOrder = int.MinValue, nFoodQuantity, nOrder;
            Queue<int> qOrdes;
            bool b = false;

            nFoodQuantity = int.Parse(Console.ReadLine());

            qOrdes = new Queue<int>(Array.ConvertAll(
                    Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries),
                    new Converter<string, int>(int.Parse))
                                    );

            for (i = qOrdes.Count; i > 0; i--)
            {
                nOrder = qOrdes.Dequeue();

                if (nMaxOrder < nOrder)
                {
                    nMaxOrder = nOrder;
                }

                if (nOrder > nFoodQuantity || b)
                {
                    b = true;
                    qOrdes.Enqueue(nOrder);
                }
                else
                {
                    nFoodQuantity -= nOrder;
                }
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(nMaxOrder);
            Console.ResetColor();

            if (qOrdes.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Orders left: {0}", String.Join(" ", qOrdes.ToArray()));
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Orders complete");
                Console.ResetColor();
            }

        }
    }
}
