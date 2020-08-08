using System;
using System.Collections.Generic;
using System.Text;

namespace _05._Date_Modifier
{
    public class DateModifier
    {
        public static double CalculateDiffInDays(string firstDate, string secondDate)
        {
            DateTime first = DateTime.Parse(firstDate);
            DateTime second = DateTime.Parse(secondDate);

            double diff = (first - second).TotalDays;
            return Math.Abs(diff);
        }
    }
}
