namespace Stealer.Core
{
    using Stealer.Core.Interfaces;
    using Stealer.IO.Interfaces;
    using Stealer.Models;
    using System;
    using System.Collections.Generic;

    public class Engine_01 : IEngine
    {
        /// <summary>
        /// 15.Lab: Reflection and Attributes
        /// 1.Stealer
        /// </summary>

        private readonly IReader reader;
        private readonly IWriter writer;


        public Engine_01(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;

        }

        public void Run()
        {
            Spy spy = new Spy();
            string result = spy.StealFieldInfo("Stealer.Hacker", "username", "password");

            Console.ForegroundColor= ConsoleColor.Green;
            writer.WriteLine(result);
            Console.ResetColor();

        }
    }
}
