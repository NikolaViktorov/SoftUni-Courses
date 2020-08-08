using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class Repository
    {

        Dictionary<int, Person> entities;

        public int Count
        {
            get => entities.Count;
        }

        public Repository()
        {
            entities = new Dictionary<int, Person>();
        }

        public void Add(Person person)
        {
            entities.Add(entities.Count, person);
        }
        public Person Get(int id)
        {
            return entities[id];
        }
        public bool Update(int id, Person newPerson)
        {
            if (entities.Count - 1 < id)
            {
                return false;
            }
            else
            {
                entities[id] = newPerson;
                return true;
            }
        }
        public bool Delete(int id)
        {
            if (entities.Count - 1 < id)
            {
                return false;
            }
            else
            {
                entities = entities
                    .Where(a => a.Key != id)
                    .ToDictionary(k => k.Key, v => v.Value);
                return true;
            }
        }
    }
}
