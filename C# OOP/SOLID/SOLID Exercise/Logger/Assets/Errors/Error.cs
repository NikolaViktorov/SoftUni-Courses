using Logger.Assets.Contracts;
using Logger.Assets.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Assets.Errors
{
    public class Error : IError
    {
        public DateTime TimeOfOccurrence { get; }

        public string Message { get; }

        public Level Level { get; }

        public Error(DateTime timeOfOccurrence, string message) :this(timeOfOccurrence, message, Level.INFO){} 

        public Error(DateTime timeOfOccurrence, string message, Level level)
        {
            this.TimeOfOccurrence = timeOfOccurrence;
            this.Message = message;
            this.Level = level;
        }
    }
}
