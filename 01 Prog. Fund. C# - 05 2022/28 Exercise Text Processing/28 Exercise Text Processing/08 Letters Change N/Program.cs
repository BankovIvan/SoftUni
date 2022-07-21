using System;

namespace _08_Letters_Change_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrStrings;
            int i;
            double nNumber, nSum = 0.00;

            arrStrings = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            
            for(i = 0; i < arrStrings.Length; i++)
            {
                nNumber = double.Parse(arrStrings[i].Substring(1, arrStrings[i].Length - 2));

                if (arrStrings[i][0] >= 'A' && arrStrings[i][0] <= 'Z')
                {
                    nNumber = nNumber / (double)(arrStrings[i][0] - 'A' + 1);
                }
                else if (arrStrings[i][0] >= 'a' && arrStrings[i][0] <= 'z')
                {
                    nNumber = nNumber * (double)(arrStrings[i][0] - 'a' + 1);
                }

                if (arrStrings[i][arrStrings[i].Length - 1] >= 'A' && arrStrings[i][arrStrings[i].Length - 1] <= 'Z')
                {
                    nNumber = nNumber - (double)(arrStrings[i][arrStrings[i].Length - 1] - 'A' + 1);
                }
                else if (arrStrings[i][arrStrings[i].Length - 1] >= 'a' && arrStrings[i][arrStrings[i].Length - 1] <= 'z')
                {
                    nNumber = nNumber + (double)(arrStrings[i][arrStrings[i].Length - 1] - 'a' + 1);
                }

                nSum += nNumber;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("{0:F2}", Math.Round(nSum, 2, MidpointRounding.AwayFromZero));
            Console.ResetColor();
        }
    }
}
