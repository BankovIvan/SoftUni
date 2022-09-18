using System;
using System.Collections.Generic;

namespace _07_Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, nFuel, nPumpCount = int.Parse(Console.ReadLine());
            Queue<int[]> qRoute = new Queue<int[]>();

            for(i = 0; i < nPumpCount; i++)
            {
                qRoute.Enqueue(Array.ConvertAll(
                    Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries),
                    new Converter<string, int>(int.Parse))
                                    );
            }

            for (i = 0; i < nPumpCount; i++)
            {
                nFuel = 0;
                foreach(var v in qRoute)
                {
                    nFuel += v[0];
                    nFuel -= v[1];
                    if(nFuel < 0)
                    {
                        break;
                    }
                }

                if(nFuel >= 0)
                {
                    Console.WriteLine(i);
                    return;
                }

                qRoute.Enqueue(qRoute.Dequeue());

            }

        }
    }
}
