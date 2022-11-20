namespace Stealer.Core
{
    using Stealer.Core.Interfaces;
    using Stealer.IO.Interfaces;
    using Stealer.Models;
    using System;
    using System.Collections.Generic;

    public class Engine_02 : IEngine
    {
        /// <summary>
        /// 15.Lab: Reflection and Attributes
        /// 2.High-Quality Mistakes
        /// </summary>

        private readonly IReader reader;
        private readonly IWriter writer;


        public Engine_02(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;

        }

        public void Run()
        {
            Spy spy = new Spy();
            string result = spy.AnalyzeAccessModifiers("Stealer.Hacker");

            Console.ForegroundColor= ConsoleColor.Green;
            writer.WriteLine(result);
            Console.ResetColor();

        }
    }
}
