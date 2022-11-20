namespace Logger.Core.Formatting.Interfaces
{
    using Logger.Core.Formatting.Layouts.Interfaces;
    using Logger.Core.Models.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IFormatter
    {
        string Format(IMessage message, ILayout layout);
    }
}
