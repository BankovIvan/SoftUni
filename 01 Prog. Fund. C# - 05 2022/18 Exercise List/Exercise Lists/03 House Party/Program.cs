using System;
using System.Collections.Generic;

namespace _03_House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, nNumCommands;
            string[] sCommand;
            List<string> lstGuests = new List<string>();

            nNumCommands = int.Parse(Console.ReadLine());

            for(i = 0; i < nNumCommands; i++)
            {
                sCommand = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (sCommand.Length == 3)
                {
                    if (lstGuests.Contains(sCommand[0]))
                    {
                        Console.WriteLine("{0} is already in the list!", sCommand[0]);
                    }
                    else
                    {
                        lstGuests.Add(sCommand[0]);
                    }
                }
                else if (sCommand.Length == 4)
                {
                    if (!lstGuests.Contains(sCommand[0]))
                    {
                        Console.WriteLine("{0} is not in the list!", sCommand[0]);
                    }
                    else
                    {
                        lstGuests.Remove(sCommand[0]);
                    }
                }
            }

            Console.WriteLine(string.Join('\n', lstGuests));

        }
    }
}
