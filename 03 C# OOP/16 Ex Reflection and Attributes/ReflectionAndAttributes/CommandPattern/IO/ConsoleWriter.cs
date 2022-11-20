namespace CommandPattern.IO
{
    using CommandPattern.IO.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text;

    public class ConsoleWriter : IWriter
    {
        private ConsoleColor foreColor;

        public ConsoleWriter()
        {
            this.foreColor = Console.ForegroundColor;
        }

        public ConsoleWriter(ConsoleColor foreColor)
        {
            this.foreColor = foreColor;
        }

        public void Write(object value)
        {
            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = this.foreColor;
            Console.Write(value.ToString());
            Console.ForegroundColor = defaultColor;
        }

        public void WriteLine(object value)
        {
            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = this.foreColor;
            Console.WriteLine(value.ToString());
            Console.ForegroundColor = defaultColor;
        }

        public void UseColor(ConsoleColor color)
        {
            this.foreColor = color;
        }

    }
}
