using System;
using System.Collections.Generic;
using System.Linq;

namespace _00._Stack_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            string sentence = Console.ReadLine();
            Stack<char> stack = new Stack<char>();

            foreach (char letter in sentence)
            {
                stack.Push(letter);
            }

            char[] a = stack.Reverse().ToArray();
            

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }
            Console.WriteLine();


            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i]);
            }
            Console.WriteLine();
        }
    }
}
