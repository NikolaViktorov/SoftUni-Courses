using Logger.Assets.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Assets.Contracts
{
    public interface IError
    {
        DateTime TimeOfOccurrence { get; }
        string Message { get; }
        Level Level { get;  }
    }
}
