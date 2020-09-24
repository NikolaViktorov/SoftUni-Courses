using Logger.Assets.Contracts;
using Logger.Assets.Enumerations;
using Logger.Assets.Errors;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Logger.Factories
{
    public class ErrorFactory
    {
        const string datetimeFormat = "M/dd/yyyy h:mm:ss tt";

        public IError GetError(string datetimeString, string levelString,
            string message)
        {
            Level level;
            bool hasParsed = Enum.TryParse<Level>(levelString, out level);

            if (hasParsed == false)
            {
                throw new InvalidCastException("Invalid Level");
            }
            level = Enum.Parse<Level>(levelString);

            DateTime timeOfOccurrence;

            try
            {
                timeOfOccurrence = DateTime.ParseExact(datetimeString, datetimeFormat,
                    CultureInfo.InvariantCulture);
            }
            catch (Exception e)
            {
                throw new InvalidTimeZoneException("Invalid Date");
            }

            return new Error(timeOfOccurrence, message, level);
        }
    }
}
