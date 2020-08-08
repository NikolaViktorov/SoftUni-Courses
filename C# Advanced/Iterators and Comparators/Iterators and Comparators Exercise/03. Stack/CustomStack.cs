using System;
using System.Collections;
using System.Collections.Generic;

namespace IteratorsAndComparatorsExercise
{
    public class CustomStack<T> : IEnumerable<T>
    {
        // fields
        private const int defaultSize = 12;
        private T[] innerArr;
        public int Count { get; private set; } = 0;
        
        // constructors
        public CustomStack()
        {
            innerArr = new T[defaultSize];
        }

        // functions
        public void Push(T element)
        {
            if (innerArr.Length == Count)
            {
                Grow();
            }
            innerArr[Count] = element;
            Count++;
        }
        public T Peek()
        {
            CheckIfEmpty();

            return innerArr[Count - 1];
        }
        public T Pop()
        {
            CheckIfEmpty();
            Count--;
            T tempElement = innerArr[Count];
            innerArr[Count] = default(T);

            return tempElement;
        }
        private void Grow()
        {
            T[] tempArr = new T[innerArr.Length * 2];

            innerArr.CopyTo(tempArr, 0);
            innerArr = tempArr;
        }
        private void CheckIfEmpty()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("No elements");
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < innerArr.Length; i++)
            {
                yield return innerArr[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
