using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        int minValue;
        int maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {

        }

        public override bool IsValid(object obj)
        {
            if ((int)obj > minValue && (int)obj < maxValue)
            {
                return true;
            }
            return false;
        }
    }
}
