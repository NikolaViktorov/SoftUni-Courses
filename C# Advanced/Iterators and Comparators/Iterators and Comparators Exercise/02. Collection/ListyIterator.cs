using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparatorsExercise
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        //fields
        List<T> items;
        int index;

        // properties
        public List<T> Items
        {
            get => items;
            set => items = value;
        }

        // constructors
        public ListyIterator(List<T> items)
        {
            this.items = new List<T>(items);
            index = 0;
        }

        // functions
        public bool HasNext()
        {
            return index < items.Count - 1;
        }
        public bool Move()
        {
            if (HasNext())
            {
                index++;
                return true;
            }
            return false;
        }
        public void Print()
        {
            if (items.Count <= 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            Console.WriteLine(items[index]);
        }
        public void PrintAll()
        {
            if (items.Count <= 0)
            {
                Console.WriteLine("Invalid Operation!");
                return;
            }
            Console.WriteLine($"{string.Join(" ", items)}");
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < items.Count; i++)
            {
                yield return items[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
