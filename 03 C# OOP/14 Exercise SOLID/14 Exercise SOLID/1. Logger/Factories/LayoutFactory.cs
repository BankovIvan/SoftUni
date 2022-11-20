namespace Logger.ConsoleApp.Factories
{
    using Logger.ConsoleApp.CustomLayouts;
    using Logger.ConsoleApp.Exceptions;
    using Logger.ConsoleApp.Factories.Interfaces;
    using Logger.Core.Formatting.Layouts;
    using Logger.Core.Formatting.Layouts.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class LayoutFactory : ILayoutFactory
    {
        public ILayout CreateLayout(string layout)
        {
            ILayout ret = null;

            if(layout == "SimpleLayout") 
            {
                ret = new SimpleLayout();
            }
            else if (layout.ToUpper() == "XMLLAYOUT")
            {
                ret = new XMLLayout();
            }
            else
            {
                throw new InvalidLayoutTypeException();
            }

            return ret;
        }
    }
}
