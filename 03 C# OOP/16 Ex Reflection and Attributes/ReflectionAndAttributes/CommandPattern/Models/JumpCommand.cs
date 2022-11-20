namespace CommandPattern.Models
{
    using CommandPattern.Core.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class JumpCommand : ICommand
    {
        private const int DEFAULT_PROGRAM_RETURN_CODE = 0;

        public string Execute(string[] args)
        {
            StringBuilder ret = new StringBuilder();

            ret.AppendLine(string.Format("Jump, {0}", args[0]));

            return ret.ToString().Trim();
        }
    }
}
