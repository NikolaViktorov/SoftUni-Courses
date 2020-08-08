using System;
using System.Linq;

namespace GenericsExercise
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Box<double> box = new Box<double>();

            for (int i = 0; i < n; i++)
            {
                double input = double.Parse(Console.ReadLine());
                box.Add(input);
            }

            double comparator = double.Parse(Console.ReadLine());

            int larger = box.GetLarger(comparator);

            Console.WriteLine(larger);
        }
    }
}
