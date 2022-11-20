namespace CommandPattern.IO.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IReader
    {
        public string Read();

        public string ReadLine();

    }
}
