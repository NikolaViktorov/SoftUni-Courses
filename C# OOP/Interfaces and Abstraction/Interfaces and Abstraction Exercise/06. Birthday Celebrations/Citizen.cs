using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06._Birthday_Celebrations
{
    public class Citizen : IBirthable
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }
        public string Birthdate { get; set; }

        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
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

        public void CheckBirthdate(string year)
        {
            string birthdateYear = Birthdate.Substring(Birthdate.Length - 4);
            if (birthdateYear == year)
            {
                Console.WriteLine(Birthdate);
            }
        }
    }
}
