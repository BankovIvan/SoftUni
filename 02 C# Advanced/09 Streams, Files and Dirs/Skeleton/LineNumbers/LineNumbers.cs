namespace LineNumbers
{
    using System.IO;
    public class LineNumbers
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    int i = 0;
                    string sInput = null;
                    while ((sInput = reader.ReadLine()) != null)
                    {
                        i++;
                        writer.WriteLine("{0}. {1}", i, sInput);
                    }
                }

                //Console.ForegroundColor = ConsoleColor.Yellow;
                //Console.WriteLine(sInput);
                //Console.ResetColor();

            }
        }
    }
}
