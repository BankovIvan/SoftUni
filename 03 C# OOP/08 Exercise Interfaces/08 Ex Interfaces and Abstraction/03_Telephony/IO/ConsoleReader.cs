namespace Telephony.IO
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Telephony.IO.Interfaces;

    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
