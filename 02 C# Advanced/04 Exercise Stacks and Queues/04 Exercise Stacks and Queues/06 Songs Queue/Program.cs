using System;
using System.Collections.Generic;

namespace _06_Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> qSongs = new Queue<string>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries));
            string sCommand, sSong;

            while(qSongs.Count > 0)
            {
                sCommand = Console.ReadLine();

                if(sCommand.Substring(0, 4)  == "Add ")
                {
                    sSong = sCommand.Substring(4);
                    if (qSongs.Contains(sSong))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("{0} is already contained!", sSong);
                        Console.ResetColor();
                    }
                    else
                    {
                        qSongs.Enqueue(sSong);
                    }
                }
                else if(sCommand == "Play")
                {
                    qSongs.Dequeue();
                }
                else if(sCommand == "Show")
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(string.Join(", ", qSongs.ToArray()));
                    Console.ResetColor();
                }

            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("No more songs!");
            Console.ResetColor();


        }
    }
}
