using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizen : ICheckable
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }
        public Citizen(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }

        public void CheckId(string lastDigits)
        {
            if (Id[Id.Length - 2] == lastDigits[1] 
                && Id[Id.Length - 3] == lastDigits[0] 
                && Id[Id.Length - 1] == lastDigits[lastDigits.Length - 1])
            {
                Console.WriteLine(Id);
            }
        }
    }
}
