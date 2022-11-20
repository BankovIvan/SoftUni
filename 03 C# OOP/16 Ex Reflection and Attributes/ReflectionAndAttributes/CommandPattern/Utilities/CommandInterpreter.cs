namespace CommandPattern.Utilities
{
    using CommandPattern.Core.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            StringBuilder ret = new StringBuilder();
            string[] cmdArguments = args.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string cmdName = cmdArguments[0];
            string[] cmdArgs = cmdArguments.Skip(1).ToArray();

            Assembly assembly = Assembly.GetEntryAssembly();
            Type intendedCommandType = assembly.GetTypes().FirstOrDefault(t => t.Name == $"{cmdName}Command");

            if (intendedCommandType == null)
            {
                throw new InvalidOperationException("Invalid command type!");
            }

            MethodInfo executeMethodInfo = intendedCommandType
                .GetMethods(BindingFlags.Instance | BindingFlags.Public)
                .FirstOrDefault(m => m.Name == "Execute");

            if(executeMethodInfo == null)
            {
                throw new InvalidOperationException("Command does not implement required pattern!");
            }

            object cmdInstance = Activator.CreateInstance(intendedCommandType);

            ret.AppendLine(
                (string)executeMethodInfo.Invoke(cmdInstance, new object[] { cmdArgs }));

            return ret.ToString().Trim();
        }
    }
}
