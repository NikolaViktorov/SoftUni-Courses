using System;
using System.Collections;

namespace GenericsExercise
{
    public class CustomList<T>
        where T : IComparable<T>, IEnumerable
    {
        private const int defaultSize = 2;

        private T[] innerArr;

        public int Count { get; private set; } = 0;

        // Creates custom integer list 
        // with default size
        public CustomList()
        {
            innerArr = new T[defaultSize];
        }

        // Creates custom T list 
        // with initial size
        public CustomList(int initialSize)
        {
            innerArr = new T[initialSize];
        }

        // Custom list indexer

        public T this[int index]
        {
            get
            {
                CheckIdexRange(index);

                return innerArr[index];
            }
            set
            {
                CheckIdexRange(index);
                innerArr[index] = value;
            }
        }

        // Adds element to the list
        public void Add(T element)
        {
            if (innerArr.Length == Count)
            {
                Grow();
            }

            innerArr[Count] = element;
            Count++;
        }

        // Adds many elements to the list

        public void AddRange(T[] list)
        {
            if (list.Length + Count >= innerArr.Length)
            {
                if (list.Length + Count > innerArr.Length * 2)
                {
                    Grow((list.Length + Count) * 2);
                }
                else
                {
                    Grow();
                }
            }

            for (int i = 0; i < list.Length; i++)
            {
                innerArr[Count] = list[i];
                Count++;
            }
        }

        // Removes element at position

        public void RemoveAt(int index)
        {
            CheckIdexRange(index);
            ShiftLeft(index);
            Count--;
            Shrink();
        }

        // Inserts element at certain position

        public void InsertAt(int index, T element)
        {
            CheckIdexRange(index);
            ShiftRight(index);
            innerArr[index] = element;
            Count++;
        }

        // Whether list contains element

        public bool Contains(T element)
        {
            bool result = false;

            for (int i = 0; i < Count; i++)
            {
                if (innerArr[i].CompareTo(element) == 0) 
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        // Swaps two elements in the list

        public void Swap(int firstIndex, int secondIndex)
        {
            CheckIdexRange(firstIndex);
            CheckIdexRange(secondIndex);
            T tempElement = innerArr[firstIndex];
            innerArr[firstIndex] = innerArr[secondIndex];
            innerArr[secondIndex] = tempElement;
        }

        // Shrinks the inner array

        public void Shrink()
        {
            if (innerArr.Length / 4 > Count)
            {
                T[] tempArr = new T[innerArr.Length / 2];

                for (int i = 0; i < Count; i++)
                {
                    tempArr[i] = innerArr[i];
                }

                innerArr = tempArr;
            }
        }

        // Iterates through the custom list

        public void ForEach(Action<T> action)
        {
            for (int i = 0; i < Count; i++)
            {
                action(innerArr[i]);
            }
        }

        #region private

        private void Grow()
        {
            Grow(innerArr.Length * 2);
        }

        private void Grow(int newSize)
        {
            T[] tempArr = new T[newSize];

            innerArr.CopyTo(tempArr, 0);
            innerArr = tempArr;
        }

        private void ShiftLeft(int position)
        {
            if (position < Count - 1)
            {
                for (int i = position; i < Count - 1; i++)
                {
                    innerArr[i] = innerArr[i + 1];
                }
            }

            innerArr[Count - 1] = default(T);
        }

        private void ShiftRight(int position)
        {
            if (innerArr.Length == Count)
            {
                Grow();
            }

            for (int i = Count - 1; i >= position; i--)
            {
                innerArr[i + 1] = innerArr[i];
            }

            innerArr[position] = default(T);
        }

        private void CheckIdexRange(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }
        }

        #endregion
    }
}
