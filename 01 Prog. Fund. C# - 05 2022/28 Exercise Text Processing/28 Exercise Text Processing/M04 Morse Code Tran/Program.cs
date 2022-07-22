using System;
using System.Collections.Generic;

namespace M04_Morse_Code_Translator
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dicMorseCode = new Dictionary<string, string>()
            {
                {".-", "A"},
                {"-...", "B"},
                {"-.-.", "C"},
                {"-..", "D"},
                {".", "E"},
                {"..-.", "F"},
                {"--.", "G"},
                {"....", "H"},
                {"..", "I"},
                {".---", "J"},
                {"-.-", "K"},
                {".-..", "L"},
                {"--", "M"},
                {"-.", "N"},
                {"---", "O"},
                {".--.", "P"},
                {"--.-", "Q"},
                {".-.", "R"},
                {"...", "S"},
                {"-", "T"},
                {"..-", "U"},
                {"...-", "V"},
                {".--", "W"},
                {"-..-", "X"},
                {"-.--", "Y"},
                {"--..", "Z"},
                {"|", " "}
            };

            string[] sInput;
            string sOutput;

            sInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            sOutput = "";

            foreach(var v in sInput)
            {
                sOutput = sOutput + dicMorseCode[v];
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(sOutput);
            Console.ResetColor();
        }
    }
}
