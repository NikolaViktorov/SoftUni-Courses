using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public string RandomString()
        {
            Random random = new Random();
            int lastIndex = this.Count - 1;
            int r = random.Next(0, lastIndex);
            string item = this[r];
            this.RemoveAt(r);
            return item;
        }
    }
}
