using System;

namespace IteratorsAndComparatorsExercise
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(new char[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries);

            CustomStack<string> stack = new CustomStack<string>();

            while (input[0] != "END")
            {
                string command = input[0];
                switch (command)
                {
                    case "Push":
                        for (int i = 1; i < input.Length; i++)
                        {
                            stack.Push(input[i]);
                        }
                        break;
                    case "Pop":
                        Console.WriteLine(stack.Pop());
                        break;
                }

                input = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var item in stack)
            {
                if (item == default(string))
                {
                    break;
                }
                Console.WriteLine(item);
            }
            foreach (var item in stack)
            {
                if (item == default(string))
                {
                    break;
                }
                Console.WriteLine(item);
            }
        }
    }
}
