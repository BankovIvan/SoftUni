using System;
using System.Collections.Generic;

namespace _06_List_Manipulation_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] sCommand;
            List<int> lstNumbers; // = new List<int>();

            lstNumbers = new List<int>(Array.ConvertAll(
                                    Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries),
                                    new Converter<string, int>(int.Parse)
                                    ));

            sCommand = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (sCommand[0] != "end")
            {

                switch (sCommand[0])
                {
                    case "Add":
                        lstNumbers.Add(int.Parse(sCommand[1]));
                        break;

                    case "Remove":
                        lstNumbers.Remove(int.Parse(sCommand[1]));
                        break;

                    case "RemoveAt":
                        lstNumbers.RemoveAt(int.Parse(sCommand[1]));
                        break;

                    case "Insert":
                        lstNumbers.Insert(int.Parse(sCommand[2]), int.Parse(sCommand[1]));
                        break;

                    default:

                        break;
                }

                sCommand = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine(string.Join(' ', lstNumbers));
        }
    }
}
