using System;
using System.Collections.Generic;

namespace _06_Cards_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lstFirstPlayer, lstSecondPlayer; // = new List<int>();
            int i, j, nSum;

            lstFirstPlayer = new List<int>(Array.ConvertAll(
                                    Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries),
                                    new Converter<string, int>(int.Parse)
                                    ));
            lstSecondPlayer = new List<int>(Array.ConvertAll(
                        Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries),
                        new Converter<string, int>(int.Parse)
                        ));
            nSum = 0;

            while (lstFirstPlayer.Count > 0 && lstSecondPlayer.Count > 0)
            {
                if(lstFirstPlayer[0] > lstSecondPlayer[0])
                {
                    lstFirstPlayer.Add(lstFirstPlayer[0]);
                    lstFirstPlayer.Add(lstSecondPlayer[0]);
                }
                else if (lstFirstPlayer[0] < lstSecondPlayer[0])
                {
                    lstSecondPlayer.Add(lstSecondPlayer[0]);
                    lstSecondPlayer.Add(lstFirstPlayer[0]);
                }

                lstFirstPlayer.RemoveAt(0);
                lstSecondPlayer.RemoveAt(0);

            }

            if(lstFirstPlayer.Count > 0)
            {
                //LAMBDA FUNCTION - Sum of all elements.
                lstFirstPlayer.ForEach(nValue => nSum += nValue);
                Console.WriteLine("First player wins! Sum: {0}", nSum);

            }
            else if (lstSecondPlayer.Count > 0)
            {
                //LAMBDA FUNCTION - Sum of all elements.
                lstSecondPlayer.ForEach(nValue => nSum += nValue);
                Console.WriteLine("Second player wins! Sum: {0}", nSum);
            }

            

        }
    }
}
