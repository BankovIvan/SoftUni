using System;
using System.Collections.Generic;

namespace _07_Append_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] sCommand;
            List<int> lstNumbers = new List<int>();
            int i;

            sCommand = Console.ReadLine().Split('|');

            for(i = sCommand.Length-1; i >= 0; i--)
            {
                lstNumbers.AddRange(Array.ConvertAll(
                                    sCommand[i].Split(' ', StringSplitOptions.RemoveEmptyEntries),
                                    new Converter<string, int>(int.Parse)
                                    ));
            }

            Console.WriteLine(string.Join(' ', lstNumbers));

        }
    }
}
