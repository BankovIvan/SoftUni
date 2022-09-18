using System;

namespace _01_Sum_Matrix_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, j, nSum = 0;
            int[] arrInput = Array.ConvertAll(
                    Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries),
                    new Converter<string, int>(int.Parse));
            int[,] arrNumbers = new int[arrInput[0], arrInput[1]];

            for(i = 0; i < arrNumbers.GetLength(0); i++)
            {
                arrInput = Array.ConvertAll(
                    Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries),
                    new Converter<string, int>(int.Parse));

                for(j = 0; j < arrNumbers.GetLength(1); j++)
                {
                    arrNumbers[i, j] = arrInput[j];
                }
            }

            foreach(var v in arrNumbers)
            {
                nSum += v;
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(arrNumbers.GetLength(0));
            Console.WriteLine(arrNumbers.GetLength(1));
            Console.WriteLine(nSum);
            Console.ResetColor();

        }
    }
}
