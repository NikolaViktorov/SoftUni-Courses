using System;
using System.Collections.Generic;
using System.Text;

namespace _06._Coding_Tracker
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class AuthorAttribute : Attribute
    {
        public string Name { get; set; }

        public AuthorAttribute(string name)
        {
            this.Name = name;
        }
    }
}
