using System;
using System.Collections.Generic;

namespace _01_Train
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] sCommand;
            List<int> lstNumbers; // = new List<int>();
            int i, nMax, nParam;

            lstNumbers = new List<int>(Array.ConvertAll(
                                    Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries),
                                    new Converter<string, int>(int.Parse)
                                    ));

            nMax = int.Parse(Console.ReadLine());

            sCommand = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (sCommand[0] != "end")
            {
                if (sCommand[0] == "Add")
                {
                    lstNumbers.Add(int.Parse(sCommand[1]));
                }
                else
                {
                    nParam = int.Parse(sCommand[0]);

                    for (i = 0; i < lstNumbers.Count; i++)
                    {
                        if ((lstNumbers[i] + nParam) <= nMax)
                        {
                            lstNumbers[i] += nParam;
                            break;
                        }
                    }

                }

                sCommand = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine(string.Join(' ', lstNumbers));

        }
    }
}
