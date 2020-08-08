using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string sentence = Console.ReadLine();

            SortedDictionary<char, int> symbols = new SortedDictionary<char, int>();

            foreach (var symbol in sentence)
            {
                if (symbols.ContainsKey(symbol) == true)
                {
                    symbols[symbol]++;
                }
                else
                {
                    symbols.Add(symbol, 1);
                }
            }

            foreach (var symbol in symbols)
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }
            
        }
    }
}
