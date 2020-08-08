using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        List<Person> people;

        public Family()
        {
            people = new List<Person>();
        }
        public void AddMember(Person member)
        {
            people.Add(member);
        }
        public Person GetOldestMember()
        {
            Person oldest = people.OrderBy(p => p.Age).LastOrDefault();
           
            return oldest;
        }
    }
}
