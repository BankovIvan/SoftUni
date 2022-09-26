namespace OddLines
{
    using System.IO;
	
    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
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
                        if ((i & 1) == 0)
                        {
                            writer.WriteLine(sInput);
                        }
                    }
                }

                //Console.ForegroundColor = ConsoleColor.Yellow;
                //Console.WriteLine(sInput);
                //Console.ResetColor();

            }

        }
    }
}
