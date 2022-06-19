using System;
using System.Collections.Generic;

namespace _05_Remove_Negatives_and_Reverse
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lstNumbers;
            int i;

            lstNumbers = new List<int>(Array.ConvertAll(
                                                Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries),
                                                new Converter<string, int>(int.Parse)
                                                ));

            for(i = 0; i < lstNumbers.Count; i++)
            {
                if(lstNumbers[i] < 0)
                {
                    lstNumbers.RemoveAt(i);
                    i--;
                }
            }

            if(lstNumbers.Count > 0)
            {
                lstNumbers.Reverse();
                Console.WriteLine(string.Join(" ", lstNumbers));
            }
            else
            {
                Console.WriteLine("empty");
            }

        }
    }
}
