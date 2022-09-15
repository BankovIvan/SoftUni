using System;
using System.Collections.Generic;

namespace _06_Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            string sInput;
            Queue<string> qCustomers = new Queue<string>();

            while (true)
            {
                sInput = Console.ReadLine();
                if(sInput == "End")
                {
                    break;
                }
                else if(sInput == "Paid")
                {
                    while(qCustomers.Count > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine(qCustomers.Dequeue());
                        Console.ResetColor();
                    }
                }
                else
                {
                    qCustomers.Enqueue(sInput);
                }

            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("{0} people remaining.", qCustomers.Count);
            Console.ResetColor();
        }
    }
}
