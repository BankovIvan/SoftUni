namespace CommandPattern.IO.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IWriter
    {
        public void Write(object value);

        public void WriteLine(object value);

        public void UseColor(ConsoleColor color);

    }
}
