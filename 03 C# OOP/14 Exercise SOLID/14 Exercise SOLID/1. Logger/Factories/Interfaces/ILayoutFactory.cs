namespace Logger.ConsoleApp.Factories.Interfaces
{
    using Logger.Core.Formatting.Layouts.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ILayoutFactory
    {
        ILayout CreateLayout(string layout);
    }
}
