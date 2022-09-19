using System;

namespace _06_Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, nRows = int.Parse(Console.ReadLine());
            int[][] arrMatrix = new int[nRows][];
            string[] arrCommand;

            for (i = 0; i < nRows; i++)
            {
                arrMatrix[i] = Array.ConvertAll(
                    Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries),
                    new Converter<string, int>(int.Parse));
            }

            StrangeEvaluate(ref arrMatrix);

            while (true)
            {
                arrCommand = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if(arrCommand[0] == "End")
                {
                    break;
                }
                else if(arrCommand[0] == "Add")
                {
                    AddArrayValue(ref arrMatrix, arrCommand);
                }
                else if (arrCommand[0] == "Subtract")
                {
                    SubtractArrayValue(ref arrMatrix, arrCommand);
                }

            }

            PrintMatrix(arrMatrix);

        }

        private static void AddArrayValue(ref int[][] arrMatrix, string[] arrCommand)
        {
            int nRow = int.Parse(arrCommand[1]);
            int nColumn = int.Parse(arrCommand[2]);
            int nValue = int.Parse(arrCommand[3]);

            if(nRow < 0 || nRow >= arrMatrix.Length)
            {
                return;
            }

            if (nColumn < 0 || nColumn >= arrMatrix[nRow].Length)
            {
                return;
            }

            arrMatrix[nRow][nColumn] += nValue;
            return;

        }

        private static void SubtractArrayValue(ref int[][] arrMatrix, string[] arrCommand)
        {
            int nRow = int.Parse(arrCommand[1]);
            int nColumn = int.Parse(arrCommand[2]);
            int nValue = int.Parse(arrCommand[3]);

            if (nRow < 0 || nRow >= arrMatrix.Length)
            {
                return;
            }

            if (nColumn < 0 || nColumn >= arrMatrix[nRow].Length)
            {
                return;
            }

            arrMatrix[nRow][nColumn] -= nValue;
            return;

        }

        private static void StrangeEvaluate(ref int[][] arrMatrix)
        {
            int i, j, k;
            int nRows = arrMatrix.Length - 1;
            int nCols;

            for (i = 0; i < nRows; i++)
            {
                k = i + 1;
                if (arrMatrix[i].Length == arrMatrix[i + 1].Length)
                {
                    for (j = 0; j < arrMatrix[i].Length; j++)
                    {
                        arrMatrix[i][j] *= 2;
                        arrMatrix[k][j] *= 2;
                    }
                }
                else
                {
                    for (j = 0; j < arrMatrix[i].Length; j++)
                    {
                        arrMatrix[i][j] /= 2;
                    }

                    nCols = arrMatrix[k].Length;
                    for (j = 0; j < nCols; j++)
                    {
                        arrMatrix[k][j] /= 2;
                    }
                }
            }

            return;
        }


        private static void PrintMatrix(int[][] arrMatrix)
        {
            int i;

            Console.ForegroundColor = ConsoleColor.DarkYellow;

            for (i = 0; i < arrMatrix.Length; i++)
            {
                Console.WriteLine(String.Join(' ', arrMatrix[i]));
            }

            Console.ResetColor();
        }
    }
}
