namespace MergeFiles
{
    using System;
    using System.IO;
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            using (StreamReader smFirst = new StreamReader(firstInputFilePath))
            {
                using (StreamReader smSecond = new StreamReader(secondInputFilePath))
                {
                    using (StreamWriter smOutput = new StreamWriter(outputFilePath))
                    {
                        string sFirstString = null;
                        string sSecondString = null;
                        while (true)
                        {
                            sFirstString = smFirst.ReadLine();
                            sSecondString = smSecond.ReadLine();

                            if (sFirstString == null && sSecondString == null)
                            {
                                break;
                            }

                            if(sFirstString != null)
                            {
                                smOutput.WriteLine(sFirstString);
                            }
                            if (sSecondString != null)
                            {
                                smOutput.WriteLine(sSecondString);
                            }

                        }

                        smOutput.Close();
                    }

                    smSecond.Close();
                }

                smFirst.Close();
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
