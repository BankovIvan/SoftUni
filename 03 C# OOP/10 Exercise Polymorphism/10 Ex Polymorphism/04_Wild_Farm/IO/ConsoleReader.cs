namespace WildFarm.IO
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WildFarm.IO.Interfaces;

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
