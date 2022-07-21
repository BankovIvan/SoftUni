using System;
using System.Text;

namespace _06_Replace_Repeating_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sInput, sOutput;
            int i;

            sInput = new StringBuilder(Console.ReadLine());
            sOutput = new StringBuilder();

            sOutput.Append(sInput[0]);
            for(i = 1; i < sInput.Length; i++)
            {
                if(sInput[i] != sInput[i - 1])
                {
                    sOutput.Append(sInput[i]);
                }
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(sOutput);
            Console.ResetColor();
        }
    }
}
