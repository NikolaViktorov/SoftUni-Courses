using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparatorsExercise
{
    public class Lake : IEnumerable<int>
    {

        int[] stones;


        public Lake(int[] stones)
        {
            this.stones = stones;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 1; i <= stones.Length; i++)
            {
                if (i % 2 != 0)
                {
                    yield return stones[i - 1];
                }
            }
            for (int i = stones.Length; i >= 1; i--)
            {
                if (i % 2 == 0)
                {
                    yield return stones[i - 1];
                }
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
