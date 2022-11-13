namespace SquareRoot.Core
{
    using SquareRoot.Core.Interfaces;
    using SquareRoot.Exceptions;
    using SquareRoot.IO;
    using SquareRoot.IO.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            string input = reader.ReadLine();
            int number = int.Parse(input);

            if(number < 0)
            {
                throw new SquareRootFromNegativeNumberException();
            }

            double result = Math.Sqrt(number);
            writer.WriteLine(result);

        }
    }
}
