namespace LineNumbers
{
    using System;
    using System.IO;
    using System.Linq;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            string[] arrLines = File.ReadAllLines(inputFilePath);
            File.Create(outputFilePath).Close();

            for (int i = 0; i < arrLines.Length; i++)
            {
                int nTotalPunctuations = arrLines[i].Where(Char.IsPunctuation).Count();
                int nTotalLetters = arrLines[i].Length - (arrLines[i].Where(Char.IsSeparator).Count() + nTotalPunctuations);

                File.AppendAllText(outputFilePath, 
                    string.Format("Line {0}: {1} ({2})({3})\n", 
                    i+1, arrLines[i], nTotalLetters, nTotalPunctuations)
                    );
            }

        }
    }
}
