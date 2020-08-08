using System;
using System.Linq;

namespace GenericsExercise
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Box<string> box = new Box<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                box.Add(input);
            }

            string comparator = Console.ReadLine();

            int larger = box.GetLarger(comparator);

            Console.WriteLine(larger);
        }
    }
}
