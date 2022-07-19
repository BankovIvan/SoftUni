using System;

namespace _04_Text_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrWords;
            System.Text.StringBuilder objText;

            arrWords = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            objText = new System.Text.StringBuilder(Console.ReadLine());

            foreach(var v in arrWords)
            {
                objText.Replace(v, new string('*', v.Length));
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(objText);
            Console.ResetColor();
        }
    }
}
