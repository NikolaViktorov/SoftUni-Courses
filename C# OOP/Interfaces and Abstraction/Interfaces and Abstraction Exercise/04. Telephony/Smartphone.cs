using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowseable
    {
        public void Browse(string site)
        {
            for (int i = 0; i < site.Length; i++)
            {
                if (char.IsDigit(site[i]))
                {
                    Console.WriteLine("Invalid URL!");
                    return;
                }
            }
            Console.WriteLine($"Browsing: {site}!");
        }

        public void Call(string number)
        {
            for (int i = 0; i < number.Length; i++)
            {
                if (char.IsDigit(number[i]) == false)
                {
                    Console.WriteLine("Invalid number!");
                    return;
                }
            }
            Console.WriteLine($"Calling... {number}");
        }
    }
}
