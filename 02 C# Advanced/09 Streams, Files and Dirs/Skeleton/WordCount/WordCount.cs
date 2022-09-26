namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            Dictionary<string, int> dicWordsCount = new Dictionary<string, int>();
            //List<string> lstText = new List<string>();

            using (StreamReader strWords = new StreamReader(wordsFilePath))
            {
                //var text = "'Oh, you can't help that,' said the Cat: 'we're all mad here. I'm mad. You're mad.'";
                //var punctuation = text.Where(Char.IsPunctuation).Distinct().ToArray();
                //var words = text.Split().Select(x => x.Trim(punctuation));

                string sAllText = strWords.ReadToEnd().ToLower();
                char[] punctuation = sAllText.Where(Char.IsPunctuation).Distinct().ToArray();

                foreach(var v in sAllText.Split(punctuation, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (!dicWordsCount.ContainsKey(v))
                    {
                        dicWordsCount.Add(v, 0);
                    }
                    //dicWordsCount[v]++;
                }
                strWords.Close();
            }

            using (StreamReader strText = new StreamReader(textFilePath))
            {
                string sAllText = strText.ReadToEnd().ToLower();
                char[] punctuation = sAllText.Where(Char.IsPunctuation).Distinct().ToArray();
                //char[] punctuation = sAllText.Where(x => char.IsPunctuation(x) || x == ' ').Distinct().ToArray();

                foreach (var v in sAllText.Split().Select(x => x.Trim(punctuation)))
                {
                    if (dicWordsCount.ContainsKey(v))
                    {
                        dicWordsCount[v]++;
                    }
                }
                strText.Close();
            }

            using (StreamWriter strOutput = new StreamWriter(outputFilePath))
            {
                foreach (var v in dicWordsCount.OrderByDescending(x => x.Value))
                {
                    strOutput.WriteLine("{0} - {1}", v.Key, v.Value);
                }
                strOutput.Close();
            }

            /*
            Console.ForegroundColor = ConsoleColor.Yellow;
            //Console.WriteLine(string.Join('\n', dicWordsCount.Keys));
            foreach(var v in dicWordsCount.OrderByDescending(x => x.Value))
            {
                Console.WriteLine("{0} - {1}", v.Key, v.Value);
            }
            Console.ResetColor();
            */

        }
    }
}
