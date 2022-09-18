using System;
using System.Collections.Generic;

namespace _10_Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int nGreenWindow, nFreeWindow, nWindow, nTotal, nTime;
            string sCommand, sCar;
            Queue<string> qCars = new Queue<string>();

            nGreenWindow = int.Parse(Console.ReadLine());
            nFreeWindow = int.Parse(Console.ReadLine());
            nWindow = nGreenWindow + nFreeWindow;
            nTotal = 0;
            sCar = "";

            while (true)
            {
                sCommand = Console.ReadLine();

                if(sCommand == "END")
                {
                    break;
                }
                else if(sCommand == "green")
                {
                    nTime = 0;
                    while (qCars.Count > 0 && nTime < nGreenWindow)
                    {
                        sCar = qCars.Dequeue();
                        if(nTime + sCar.Length <= nWindow)
                        {
                            nTime += sCar.Length;
                            nTotal++;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine("{0} was hit at {1}.", sCar, sCar[nWindow - nTime]);
                            Console.ResetColor();
                            return;
                        }
                    }
                }
                else
                {
                    qCars.Enqueue(sCommand);
                }

            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine("{0} total cars passed the crossroads.", nTotal);
            Console.ResetColor();

        }
    }
}
