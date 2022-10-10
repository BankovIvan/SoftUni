namespace _01_Generic_Box_of_String
{
    using System;

    internal class Program
    {
        static void Main(string[] args)
        {
            int nRepeat = int.Parse(Console.ReadLine());

            for(int i = 0; i < nRepeat; i++)
            {
                Box<string> objBox = new Box<string>(Console.ReadLine());

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(objBox);
                Console.ResetColor();
            }


        }
    }
}

