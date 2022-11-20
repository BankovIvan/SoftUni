namespace CommandPattern.Core
{
    using CommandPattern.Core.Contracts;
    using CommandPattern.IO;
    using CommandPattern.IO.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private ICommandInterpreter interpreter;

        public Engine(IReader reader, IWriter writer, ICommandInterpreter commandInterpreter)
        {
            this.reader = reader;
            this.writer = writer;
            this.interpreter = commandInterpreter;
        }

        public Engine()
        {
            this.reader = new ConsoleReader();
            this.writer = new ConsoleWriter();
            this.interpreter = null;
        }

        public Engine(ICommandInterpreter commandInterpreter) : this()
        {
            this.interpreter = commandInterpreter;
        }

        public void Run()
        {
            while(true)
            {
                try
                {
                    string input = reader.ReadLine();
                    string result = this.interpreter.Read(input);

                    this.writer.UseColor(ConsoleColor.Blue);
                    this.writer.WriteLine(result);
                }
                catch(InvalidOperationException ex)
                {
                    this.writer.UseColor(ConsoleColor.Red);
                    this.writer.WriteLine(ex.Message);
                }

            }
        }
    }
}
