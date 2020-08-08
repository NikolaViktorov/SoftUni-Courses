using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        List<T> items;
        int count;
        public Box()
        {
            items = new List<T>();
            count = 0;
        }
        public int Count
        {
            get => count;
        }
        public void Add(T item)
        {
            items.Add(item);
            count++;
        }
        public T Remove()
        {
            if (count > 0)
            {
                T lastElement = items.Last();
                items.RemoveAt(count - 1);
                count--;
                return lastElement;
            }
            throw new ArgumentException("Not enought elements in the collection!");
        }
    }
}
