namespace _03_Word_Synonyms
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    //using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, List<string>> dicSynonyms = new Dictionary<string, List<string>>();
            string sWord;
            int i, nRepeat;

            nRepeat = int.Parse(Console.ReadLine());

            for(i = 0; i < nRepeat; i++){
                sWord = Console.ReadLine();
                if(! dicSynonyms.ContainsKey(sWord))
                {
                    dicSynonyms.Add(sWord, new List<string>());
                }

                dicSynonyms[sWord].Add(Console.ReadLine());

            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach(var v in dicSynonyms){
                Console.WriteLine(v.Key + " - " + string.Join(", ", v.Value));
            }           
            Console.ResetColor();

        }
    }
}