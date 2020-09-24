using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stack = new StackOfStrings();

            Console.WriteLine(stack.IsEmpty());

            Stack<string> curStack = new Stack<string>();

            curStack.Push("b");
            curStack.Push("c");

            Stack<string> newStack = stack.AddRange(curStack);

            Console.WriteLine(stack.IsEmpty());
            Console.WriteLine(string.Join(", ", newStack));
        }
    }
}
