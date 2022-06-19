using System;
using System.Collections.Generic;

namespace _05_Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lstNumbers; // = new List<int>();
            int i, j, nBomb, nPower, nSum;
            string[] arrCommand;

            lstNumbers = new List<int>(Array.ConvertAll(
                                    Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries),
                                    new Converter<string, int>(int.Parse)
                                    ));

            arrCommand = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            nBomb = int.Parse(arrCommand[0]);
            nPower = int.Parse(arrCommand[1]);
            nSum = 0;

            for(i = 0; i < lstNumbers.Count; i++)
            {

                if(lstNumbers[i] == nBomb)
                {
                    j = i + nPower;
                    i = i - (nPower + 1);

                    if (j >= lstNumbers.Count)
                    {
                        j = lstNumbers.Count - 1;
                    }

                    if (i < -1)
                    {
                        i = -1;
                    }

                    for (; j > i; j--)
                    {
                        lstNumbers.RemoveAt(j);
                    }
                }

                //Console.WriteLine(string.Join(' ', lstNumbers));

            }

            //LAMBDA FUNCTION - Sum of all elements.
            lstNumbers.ForEach(nValue => nSum += nValue);

            Console.WriteLine(nSum);
        }
    }
}
