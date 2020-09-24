using Logger.Assets.Contracts;
using Logger.Assets.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Factories
{
    public class LayoutFactory
    {
        public ILayout GetLayout(string type)
        {
            ILayout layout;

            if (type == "SimpleLayout")
            {
                layout = new SimpleLayout();
            }
            else if (type == "XmlLayout")
            {
                layout = new XmlLayout();
            }
            else
            {
                throw new InvalidOperationException("Invalid Type");
            }
            return layout;
        }
    }
}
