using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06._Birthday_Celebrations
{
    public class Pet : IBirthable
    {
        public string Name { get; set; }
        public string Birthdate { get; set; }

        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
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
