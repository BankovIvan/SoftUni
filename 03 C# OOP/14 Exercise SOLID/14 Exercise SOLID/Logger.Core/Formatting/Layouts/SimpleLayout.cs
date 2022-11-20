namespace Logger.Core.Formatting.Layouts
{
    using Logger.Core.Formatting.Layouts.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SimpleLayout : ILayout
    {
        private const string format = "{0} - {1} - {2}";

        public string Format { get { return format; } }
    }
}
