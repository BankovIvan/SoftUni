namespace Logger.ConsoleApp.CustomLayouts
{
    using Logger.Core.Formatting.Layouts.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class XMLLayout : ILayout
    {
        public string Format => this.CreateFormat();

        public XMLLayout() { }

        private string CreateFormat()
        {
            StringBuilder ret = new StringBuilder();

            ret.AppendLine("<log>");
            ret.AppendLine("\t<date>{0}</date>");
            ret.AppendLine("\t<level>{1}</level>");
            ret.AppendLine("\t<message>{2}</message>");
            ret.AppendLine("</log>");

            return ret.ToString().Trim();  
        }
    }
}
