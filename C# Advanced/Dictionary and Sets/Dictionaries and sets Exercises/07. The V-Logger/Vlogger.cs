using System.Collections.Generic;

namespace _07._The_V_Logger
{
    internal class Vlogger
    {
        string name;
        public List<string> following { get; set; }
        public List<string> followers { get; set; }
        
        public string Name
        {
            get => name;
            set => name = value;
        }

        public Vlogger(string name)
        {
            following = new List<string>();
            followers = new List<string>();
            this.name = name;
        }


    }
}