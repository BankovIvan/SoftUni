using CommandPattern.Core;
using CommandPattern.Core.Contracts;
using CommandPattern.Utilities;
using System;
using System.Reflection;

namespace CommandPattern
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ICommandInterpreter command = new CommandInterpreter();
            IEngine engine = new Engine(command);
            engine.Run();

        }
    }
}
