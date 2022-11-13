namespace SquareRoot.IO
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using SquareRoot.IO.Interfaces;

    public class ConsoleReader : IReader
    {
        public ConsoleReader()
        {

        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
