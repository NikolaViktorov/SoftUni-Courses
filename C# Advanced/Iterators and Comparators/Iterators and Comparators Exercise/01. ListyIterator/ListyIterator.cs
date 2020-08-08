using System;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparatorsExercise
{
    public class ListyIterator<T>
    {
        List<T> items;
        int index;

        public List<T> Items
        {
            get => items;
            set => items = value;
        }

        public ListyIterator(List<T> items)
        {
            this.items = new List<T>(items);
            index = 0;
        }

        public bool HasNext()
        {
            return items.Count - 1 > index; // ++index < items.Count - 1;
        }
        public bool Move()
        {
            index++;
            return true;
        }
        public void Print()
        {
            if (items.Count <= 0)
            {
                Console.WriteLine("Invalid Operation!");
                return;
            }
            Console.WriteLine(items[index]);
        }



    }
}
