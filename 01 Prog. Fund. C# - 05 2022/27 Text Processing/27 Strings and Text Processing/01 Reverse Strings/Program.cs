using System;
using System.Text;

namespace _01_Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string sInput;
            StringBuilder objReverse = new StringBuilder();
            int i;

            while (true)
            {
                sInput = Console.ReadLine();
                if(sInput == "end")
                {
                    break;
                }

                objReverse.Append(sInput);
                objReverse.Append(" = ");
                for (i = sInput.Length - 1; i >= 0; i--)
                {
                    objReverse.Append(sInput[i]);
                }
                objReverse.AppendLine();
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(objReverse);
            Console.ResetColor();

        }
    }
}
