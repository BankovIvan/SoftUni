namespace WildFarm.IO
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WildFarm.IO.Interfaces;

    public class ConsoleWriter : IWriter
    {
        public ConsoleWriter()
        {

        }

        public void Write(object value)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(value.ToString());
            Console.ResetColor();
        }

        public void WriteLine(object value)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(value.ToString());
            Console.ResetColor();
        }
    }
}
