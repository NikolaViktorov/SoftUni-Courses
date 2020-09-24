using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Assets.Contracts
{
    public interface ILogger
    {
        IReadOnlyCollection<IAppender> Appenders { get; }
        void Log(IError error);
    }
}
