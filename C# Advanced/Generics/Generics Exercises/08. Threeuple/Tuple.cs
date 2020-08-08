using System;
using System.Collections.Generic;
using System.Text;

namespace GenericsExercise
{
    public class Tuple<T, F, Z>
    {
        T firstItem;
        F secondItem;
        Z thirdItem;

        public Tuple(T firstItem, F secondItem, Z thirdItem)
        {
            this.firstItem = firstItem;
            this.secondItem = secondItem;
            this.thirdItem = thirdItem;
        }

        public override string ToString()
        {
            return $"{firstItem} -> {secondItem} -> {thirdItem}";
        }
    }
}
