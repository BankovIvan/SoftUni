namespace EvenLines
{
    using System;
    using System.IO;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            string ret = "";

            using(StreamReader srLines = new StreamReader(inputFilePath))
            {
                string sLine = null;
                int i = 0;
                char[] arrPunctuation = new char[] { '-', ',', '.', '!', '?' };

                while (true)
                {
                    sLine = srLines.ReadLine();
                    if(sLine == null)
                    {
                        break;
                    }

                    foreach(var v in arrPunctuation)
                    {
                        sLine = sLine.Replace(v, '@');
                    }

                    string[] arrWords = sLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    Array.Reverse(arrWords);

                    if ((i++ & 1) == 0)
                    {
                        ret = ret + string.Join(" ", arrWords) + "\n";
                    }
                    
                }

            }

            return ret;

        }
    }
}
