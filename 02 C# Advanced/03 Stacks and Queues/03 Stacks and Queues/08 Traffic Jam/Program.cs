using System;
using System.Collections.Generic;

namespace _08_Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> qCars = new Queue<string>();
            int i, nSum = 0, nPass = int.Parse(Console.ReadLine());
            string sCar;

            while (true)
            {
                sCar = Console.ReadLine();
                if(sCar == "end")
                {
                    break;
                }
                else if(sCar == "green")
                {
                    for(i = 0; i < nPass && qCars.Count > 0; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("{0} passed!", qCars.Dequeue());
                        Console.ResetColor();

                        nSum++;
                    }
                }
                else
                {
                    qCars.Enqueue(sCar);
                }

            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("{0} cars passed the crossroads.", nSum);
            Console.ResetColor();

        }
    }
}
