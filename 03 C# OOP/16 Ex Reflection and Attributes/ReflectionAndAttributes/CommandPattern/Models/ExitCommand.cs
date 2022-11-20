namespace CommandPattern.Models
{
    using CommandPattern.Core.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ExitCommand : ICommand
    {
        private const int DEFAULT_PROGRAM_RETURN_CODE = 0;

        public string Execute(string[] args)
        {
            string ret = null;

            Environment.Exit(DEFAULT_PROGRAM_RETURN_CODE);

            return ret;
        }
    }
}
