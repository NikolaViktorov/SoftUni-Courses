using Logger.Assets.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Assets.Layouts
{
    public class XmlLayout : ILayout
    {
        public string Format => "<log>" + Environment.NewLine    
            + "\t<date>{0}</date>" + Environment.NewLine     
            + "\t<level>{1}</level>" + Environment.NewLine  
            + "\t<message>{2}</message>" + Environment.NewLine
            + "</log>";
    }
}
