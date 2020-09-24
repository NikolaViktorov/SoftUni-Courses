using Logger.Assets.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Assets.Contracts
{
    public interface IAppender
    {
        ILayout Layout { get; }
        Level Level { get; set; }
        int MessagesCount { get; }
        void Append(IError error);
    }
}
