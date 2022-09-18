using System;

namespace _06_Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, j, nValue, nFirstDimension = int.Parse(Console.ReadLine());
            int[][] arrNumbers = new int[nFirstDimension][];
            char[] arrSplit = { ',', ' ' };
            string[] arrInput;

            for (i = 0; i < nFirstDimension; i++)
            {
                arrNumbers[i] = Array.ConvertAll(
                    Console.ReadLine().Split(arrSplit, StringSplitOptions.RemoveEmptyEntries),
                    new Converter<string, int>(int.Parse));
            }

            while (true)
            {
                arrInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if(arrInput[0] == "END")
                {
                    break;
                }

                i = int.Parse(arrInput[1]);
                j = int.Parse(arrInput[2]);

                if (i < 0 || i >= arrNumbers.Length)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Invalid coordinates");
                    Console.ResetColor();
                    continue;
                }

                if (j < 0 || j >= arrNumbers[i].Length)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Invalid coordinates");
                    Console.ResetColor();
                    continue;
                }

                nValue = int.Parse(arrInput[3]);
                if (arrInput[0] == "Add")
                {
                    arrNumbers[i][j] += nValue;
                }
                else if (arrInput[0] == "Subtract")
                {
                    arrNumbers[i][j] -= nValue;
                }

            }

            for(i = 0; i < arrNumbers.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(string.Join(' ', arrNumbers[i]));
                Console.ResetColor();
            }

        }
    }
}
