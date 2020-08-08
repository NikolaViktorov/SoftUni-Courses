using System;
using System.Collections.Generic;
using System.Text;

namespace GenericsExercise
{
    public class Box<T>
    {
        List<T> coll;
        public Box()
        {
            coll = new List<T>();
        }
        public void Add(T item)
        {
            coll.Add(item);
        }
        public override string ToString()
        {
            string result = $"{coll[0].GetType()} : {coll[0]}" + Environment.NewLine;
            for (int i = 1; i < coll.Count; i++)
            {
                result += $"{coll[i].GetType().FullName} : {coll[i]}" + Environment.NewLine;
            }
            return result.ToString().TrimEnd();
        }
        public void Swap(int firstIndex, int secondIndex)
        {
            T temp = coll[firstIndex];
            coll[firstIndex] = coll[secondIndex];
            coll[secondIndex] = temp;
        }
    }
}
