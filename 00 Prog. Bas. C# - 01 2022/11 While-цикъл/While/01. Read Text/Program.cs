using System;

namespace _01._Read_Text
{
    class Program
    {
        static void Main(string[] args)
        {

            string sWord = "";

            sWord = Console.ReadLine();

            while (sWord != "Stop")
            {
                Console.WriteLine(sWord);
                sWord = Console.ReadLine();

            }


        }
    }
}
