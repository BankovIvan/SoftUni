using System;

namespace _05_Digits__Letters_and_Oth
{
    class Program
    {
        static void Main(string[] args)
        {
            string sInput;
            System.Text.StringBuilder objLetters = new System.Text.StringBuilder();
            System.Text.StringBuilder objNumbers = new System.Text.StringBuilder();
            System.Text.StringBuilder objOthers = new System.Text.StringBuilder();
            int i;

            sInput = Console.ReadLine();
            
            for(i = 0; i < sInput.Length; i++)
            {
                //if((sInput[i] >= 'a' && sInput[i] <= 'z') || (sInput[i] >= 'A' && sInput[i] <= 'Z'))
                if(char.IsLetter(sInput[i]))
                {
                    objLetters.Append(sInput[i]);
                }
                else if(char.IsDigit(sInput[i]))
                //else if(sInput[i] >= '0' && sInput[i] <= '9')
                {
                    objNumbers.Append(sInput[i]);
                }
                else
                {
                    objOthers.Append(sInput[i]);
                }
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(objNumbers);
            Console.WriteLine(objLetters);
            Console.WriteLine(objOthers);
            Console.ResetColor();
        }
    }
}
