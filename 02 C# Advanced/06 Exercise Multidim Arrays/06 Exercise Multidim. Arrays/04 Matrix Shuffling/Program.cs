using System;

namespace _04_Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {

            int i = -1, j = -1, k = -1, l = -1;
            int[] arrDim = Array.ConvertAll(
                    Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries),
                    new Converter<string, int>(int.Parse));
            string[][] arrMatrix = new string[arrDim[0]][];
            string[] arrInput;
            string sElement;

            for (i = 0; i < arrDim[0]; i++)
            {
                arrMatrix[i] = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            while (true)
            {
                arrInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if(arrInput[0] == "END")
                {
                    break;
                }
                else if(arrInput[0] == "swap" && arrInput.Length == 5)
                {
                    i = int.Parse(arrInput[1]);
                    j = int.Parse(arrInput[2]);
                    k = int.Parse(arrInput[3]);
                    l = int.Parse(arrInput[4]);

                    if(i >=0 && i < arrMatrix.Length)
                    {
                        if(j >= 0 && j < arrMatrix[i].Length)
                        {
                            if (k >= 0 && k < arrMatrix.Length)
                            {
                                if (l >= 0 && l < arrMatrix[k].Length)
                                {
                                    sElement = arrMatrix[i][j];
                                    arrMatrix[i][j] = arrMatrix[k][l];
                                    arrMatrix[k][l] = sElement;
                                    PrintMatrix(arrMatrix);
                                    continue;

                                }
                            }
                        }
                    }
                }

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Invalid input!");
                Console.ResetColor();

            }

        }

        private static void PrintMatrix(string[][] arrMatrix)
        {
            int i;

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            for(i = 0; i < arrMatrix.Length; i++)
            {
                Console.WriteLine(String.Join(' ', arrMatrix[i]));
            }
            Console.ResetColor();
        }
    }
}
