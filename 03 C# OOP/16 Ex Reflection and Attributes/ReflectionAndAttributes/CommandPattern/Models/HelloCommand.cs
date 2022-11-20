namespace CommandPattern.Models
{
    using CommandPattern.Core.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class HelloCommand : ICommand
    {
        public string Execute(string[] args)
        {
            StringBuilder ret = new StringBuilder();

            ret.AppendLine(string.Format("Hello, {0}", args[0]));

            return ret.ToString().Trim();
        }
    }
}
