namespace _02_Generic_Box_of_Integer
{
    using System;

    internal class Program
    {
        static void Main(string[] args)
        {
            int nRepeat = int.Parse(Console.ReadLine());

            for (int i = 0; i < nRepeat; i++)
            {
                Box<int> objBox = new Box<int>(int.Parse(Console.ReadLine()));

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(objBox);
                Console.ResetColor();
            }


        }
    }
}
