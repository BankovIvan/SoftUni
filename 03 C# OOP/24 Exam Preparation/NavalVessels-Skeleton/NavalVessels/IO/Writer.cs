namespace NavalVessels.IO
{
    using System;

    using Contracts;

    public class Writer : IWriter
    {
        public void Write(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(message);
            Console.ResetColor();
        }

        public void WriteLine(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
