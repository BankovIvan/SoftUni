namespace Stealer.Core
{
    using Stealer.Core.Interfaces;
    using Stealer.IO.Interfaces;
    using Stealer.Models;
    using System;
    using System.Collections.Generic;

    public class Engine_03 : IEngine
    {
        /// <summary>
        /// 15.Lab: Reflection and Attributes
        /// 3.Mission Private Impossible
        /// </summary>

        private readonly IReader reader;
        private readonly IWriter writer;


        public Engine_03(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;

        }

        public void Run()
        {
            Spy spy = new Spy();
            string result = spy.RevealPrivateMethods("Stealer.Hacker");

            Console.ForegroundColor= ConsoleColor.Green;
            writer.WriteLine(result);
            Console.ResetColor();

        }
    }
}
