namespace CommandPattern.IO
{
    using CommandPattern.IO.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ConsoleReader : IReader
    {
        public ConsoleReader() 
        {

        }

        public string Read()
        {
            return Console.Read().ToString();
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
