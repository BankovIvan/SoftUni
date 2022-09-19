using System;

namespace _06_Snake_Moves
{

    public class StringStream
    {
        public string Value { get; set; }
        public int Position { get; set; }

        public StringStream(string Value)
        {
            this.Value = Value;
            this.Position = 0;
        }

        public override string ToString()
        {
            return this.Value + "/" + this.Position;
        }

        public string GetNext()
        {
            string ret = this.Value[this.Position].ToString();
            this.Position++;
            if(this.Position >= this.Value.Length)
            {
                this.Position = 0;
            }
            return ret;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            int i, j;
            int[] arrDim = Array.ConvertAll(
                    Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries),
                    new Converter<string, int>(int.Parse));
            StringStream objSnake = new StringStream(Console.ReadLine());
            string[,] arrMatrix = new string[arrDim[0], arrDim[1]];
            bool bRight = true;

            for(i = 0; i < arrDim[0]; i++)
            {
                if(bRight == true)
                {
                    for(j = 0; j < arrDim[1]; j++)
                    {
                        arrMatrix[i, j] = objSnake.GetNext();
                    }
                }
                else
                {
                    for (j = arrDim[1] - 1; j >= 0; j--)
                    {
                        arrMatrix[i, j] = objSnake.GetNext();
                    }
                }
                bRight = !bRight;
            }

            PrintMatrix(arrMatrix, "");
        }

        private static void PrintMatrix(string[,] arrMatrix, string sSeparator = " ")
        {
            int i, j, nRows = arrMatrix.GetLength(0), nCols = arrMatrix.GetLength(1);

            Console.ForegroundColor = ConsoleColor.DarkYellow;

            for (i = 0; i < nRows; i++)
            {
                for(j = 0; j < nCols; j++)
                {
                    if(j > 0)
                    {
                        Console.Write(sSeparator);
                    }
                    Console.Write(arrMatrix[i, j]);
                }
                Console.WriteLine();
            }

            Console.ResetColor();

            return;

        }

    }
}
