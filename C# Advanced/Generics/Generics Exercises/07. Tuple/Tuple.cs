using System;
using System.Collections.Generic;
using System.Text;

namespace GenericsExercise
{
    public class Tuple<T, F>
    {
        T firstItem;
        F secondItem;

        public Tuple(T firstItem, F secondItem)
        {
            this.firstItem = firstItem;
            this.secondItem = secondItem;
        }

        public override string ToString()
        {
            return $"{firstItem} -> {secondItem}";
        }
    }
}
