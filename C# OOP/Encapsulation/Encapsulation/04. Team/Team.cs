using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Team
    {
        string name;
        List<Person> firstTeam;
        List<Person> reserveTeam;

        public IReadOnlyCollection<Person> FirstTeam
        {
            get => firstTeam.AsReadOnly();
        }
        public IReadOnlyCollection<Person> ReserveTeam
        {
            get => reserveTeam.AsReadOnly();
        }

        public Team(string name)
        {
            this.name = name;
            this.firstTeam = new List<Person>();
            this.reserveTeam = new List<Person>();
        }
        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                firstTeam.Add(person);
            }
            else
            {
                reserveTeam.Add(person);
            }
        }
    }
}
